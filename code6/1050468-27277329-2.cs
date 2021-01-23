    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    
    using AForge;
    using AForge.Video;
    using AForge.Controls;
    using AForge.Video.DirectShow;
    
    namespace AddPanel
    {
        public partial class test : UserControl
        {    
    
            public test()
            {
                Form1 f1 = new Form1();
                JPEGStream jpegSource1 = new JPEGStream("http://" + f1.IPadd + "/jpg/image.jpg?resolution=320x240");
                jpegSource1.Login = f1.UsrID;
                jpegSource1.Password = f1.pswd;
                jpegSource1.NewFrame += new NewFrameEventHandler(jpegSource1_NewFrame);
                //source1.VideoSourceError += new VideoSourceErrorEventHandler(source1_VideoSourceError);
                jpegSource1.VideoSourceError += new VideoSourceErrorEventHandler(jpegSource1_VideoSourceError);
                Player1.VideoSource = jpegSource1;
    
                InitializeComponent();
            }
    
            void jpegSource1_NewFrame(object sender, NewFrameEventArgs eventArgs)
            {
                Bitmap image = new Bitmap(eventArgs.Frame, 320, 240);
    
                image.Save(ws, System.Drawing.Imaging.ImageFormat.Bmp);
            }
    
            void jpegSource1_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
            {
                //Error handler
                Debug.WriteLine(eventArgs.Description);
    
                Bitmap ErPic = new Bitmap(320, 240);
                using (var g = Graphics.FromImage(ErPic))
                {
                    using (var arialFontLarge = new Font("Arial", 15))
                    {
                        g.DrawString("Camera Offline", arialFontLarge, Brushes.White, 75, 100);
                    }
    
                }
                ErPic.Save(ws, ImageFormat.Bmp);
            }
    
            private void StartBut_Click(object sender, EventArgs e)
            {
                Player1.VideoSource.Start();
            }
    
            private void StopBut_Click(object sender, EventArgs e)
            {
                Player1.VideoSource.Stop();
                ws.Close();
            }
        }
    }
