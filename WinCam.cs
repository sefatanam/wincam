using System;
using System.Windows.Forms;

namespace WinCam
{
    public partial class WinCam : Form
    {
        public WinCam()
        {
            InitializeComponent();
            StartButton.Hide();
            StopButton.Hide();
            ExitButton.Hide();
            AddNewIpButton.Show();

        }

        private string IpAddress { get; set; }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(IpAddress))
                {
                    StartButton.Text = "Start";
                    videoCapture1.IP_Camera_Source = new VisioForge.Types.Sources.IPCameraSourceSettings()
                    { URL = $"{IpAddress}", Type = VisioForge.Types.VFIPSource.Auto_LAV }; /*like this type:-http://192.168.233.129:8000/camera/mjpeg*/
                    videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;
                    videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.IPPreview;
                    videoCapture1.Start();

                    //here need a validation, sometimes if IP goes offline it occured error
                }
                else
                {
                    StartButton.Text = "Not Ready";
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong. Check Ip Address again.");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                videoCapture1.Stop();
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }

        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            try
            {
                //http:192.168.0.100 if need to validate this as entried IP_Address,here the right place. Put Here Your Code.


                if (!String.IsNullOrEmpty(ipAddressTextBox.Text))
                {
                    IpAddress = ipAddressTextBox.Text;
                    MessageBox.Show("Ip Address entried successfully");
                    StartButton.Show();
                    StopButton.Show();
                    ExitButton.Show();
                    AddNewIpButton.Show();
                    ipLabel.Hide();
                    ipAddressTextBox.Hide();
                    SetButton.Hide();
                }
                else if (String.IsNullOrEmpty(ipAddressTextBox.Text))
                {
                    MessageBox.Show("Ip is not provided or empty.");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            try { Close(); } catch { MessageBox.Show("Something went wrong."); }

        }

        private void AddNewIpButton_Click(object sender, EventArgs e)
        {

            videoCapture1.Stop();
            ipLabel.Show();
            ipAddressTextBox.Show();
            SetButton.Show();
            StartButton.Hide();
            StopButton.Hide();
            ExitButton.Hide();
            AddNewIpButton.Hide();

        }
    }
}
