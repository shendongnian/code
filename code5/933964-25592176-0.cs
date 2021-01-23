        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using AForge.Video;
    using AForge.Video.DirectShow;
    using AForge.Video.FFMPEG;
    using AForge.Video.VFW;
    
    namespace WindowsFormsApplication12
    {
        public partial class Form1 : Form
        {
            private FilterInfoCollection VideoCaptureDevices;
       
            private VideoCaptureDevice FinalVideo = null;
            private VideoCaptureDeviceForm captureDevice;
            private Bitmap video;
            //private AVIWriter AVIwriter = new AVIWriter();
            private VideoFileWriter FileWriter = new VideoFileWriter();
            private SaveFileDialog saveAvi;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                
     
                VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                captureDevice = new VideoCaptureDeviceForm();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (captureDevice.ShowDialog(this) == DialogResult.OK)
                {
                    
                    VideoCaptureDevice videoSource = captureDevice.VideoDevice;
                    FinalVideo = captureDevice.VideoDevice;
                    FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                    FinalVideo.Start();
                }
            }
            void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
            {
                if (butStop.Text == "Stop Record")
                {
                    video = (Bitmap)eventArgs.Frame.Clone();
                    pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                    //AVIwriter.Quality = 0;
                    FileWriter.WriteVideoFrame(video);
                    //AVIwriter.AddFrame(video);
                }
                else
                {
                    video = (Bitmap)eventArgs.Frame.Clone();
                    pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                saveAvi = new SaveFileDialog();
                saveAvi.Filter = "Avi Files (*.avi)|*.avi";
                if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int h = captureDevice.VideoDevice.VideoResolution.FrameSize.Height;
                    int w = captureDevice.VideoDevice.VideoResolution.FrameSize.Width;
                    FileWriter.Open(saveAvi.FileName, w, h,25,VideoCodec.Default,5000000);
                    FileWriter.WriteVideoFrame(video);
    
                    //AVIwriter.Open(saveAvi.FileName, w, h);
                    butStop.Text = "Stop Record";
                    //FinalVideo = captureDevice.VideoDevice;
                    //FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                    //FinalVideo.Start();
                }
            }
    
            private void butStop_Click(object sender, EventArgs e)
            {
                if (butStop.Text == "Stop Record")
                {
                    butStop.Text = "Stop";
                    if (FinalVideo == null)
                    { return; }
                    if (FinalVideo.IsRunning)
                    {
                        //this.FinalVideo.Stop();
                        FileWriter.Close();
                        //this.AVIwriter.Close();
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    this.FinalVideo.Stop();
                    FileWriter.Close();
                    //this.AVIwriter.Close();
                    pictureBox1.Image = null;
                }
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                pictureBox1.Image.Save("IMG" + DateTime.Now.ToString("hhmmss") + ".jpg");
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (FinalVideo == null)
                { return; }
                if (FinalVideo.IsRunning)
                {
                    this.FinalVideo.Stop();
                    FileWriter.Close();
                    //this.AVIwriter.Close();
                }
            }
    
    
        }
    }
