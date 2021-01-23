    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AForge;
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using AForge.Video;
    using AForge.Video.DirectShow;
    using System.Drawing.Imaging;       //Save P2
    using System.IO;                    //Save P2
    
    namespace AForgeCamera
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
           
            Bitmap video;
            
            private FilterInfoCollection CaptureDevice;
            private VideoCaptureDevice FinalFrame;
            int mode;
        
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo Device in CaptureDevice)
                {
                    comboBox1.Items.Add(Device.Name);
                }
                comboBox1.SelectedIndex = 0;
                FinalFrame = new VideoCaptureDevice();
            }
    
            private void button1_Click(object sender, EventArgs e)      //Tombol Start
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                FinalFrame.Start();
            }
            void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
            {
                video = (Bitmap)eventArgs.Frame.Clone();
                Bitmap video2 = (Bitmap)eventArgs.Frame.Clone();
                if (mode==1)
                {
                    Grayscale gray = new Grayscale(0.2125, 0.7154, 0.0721);
                    Bitmap video3 = gray.Apply(video2);
                    CannyEdgeDetector canny = new CannyEdgeDetector(0, 70);
                    canny.ApplyInPlace(video3);
                    pictureBox2.Image = video3;
                }
                pictureBox1.Image = video;
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (FinalFrame.IsRunning == true)
                {
                    FinalFrame.Stop();
                }
            }
    
            private void btnTrackingObject_Click(object sender, EventArgs e)
            {
                mode = 1;
            }
    
            
        }
    }
