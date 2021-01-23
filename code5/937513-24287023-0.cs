        using System;
        
        using System.Collections.Generic;
        
        using System.ComponentModel;
        
        using System.Data;
        
        using System.Drawing;
        
        using System.Linq;
        
        using System.Text;
        
        using System.Windows.Forms;
        
        using Emgu.CV;
        
        using Emgu.CV.UI;
        
        using Emgu.CV.CvEnum;
        
        using Emgu.CV.Structure;
        
        using System.Diagnostics;
        
        using System.IO;
        
        using System.Data.SqlClient;
        
        using System.Data.SqlServerCe;
        
        using System.Drawing.Imaging;
        
        namespace ptuxiakh___
        {
            public partial class Form1 : Form
            {
        
        
        Capture _capture = new Capture();
        
        Capture capture2 = new Capture();
        
        Image<Bgr, Byte> FirstImage = new Image<Bgr, Byte>(640, 480);
        Image<Bgr, Byte> RealTimeImage = new Image<Bgr, Byte>(640, 480);
        
        Image<Gray, Byte> des = new Image<Gray, Byte>(640, 480);
        Image<Gray, Byte> thres = new Image<Gray, Byte>(640, 480);
        Image<Gray, Byte> eroded = new Image<Gray, Byte>(640, 480);
        
        bool baground = false;
        
        
         private void Background()
                {
        
                    try{
                    FirstImage = capture5.QueryFrame();
                    baground = true;
         
                     }
                    catch(Exception e)
                      {
                      baground = false;
                      }
                }
        
         private void Tracking(object sender, EventArgs e)
                {
        
          if (baground == true)
                    {
         RealTimeImage   = capture2.QueryFrame();
        
                        CvInvoke.cvAbsDiff(FirstImage.Convert<Gray, Byte>(), RealTimeImage.Convert<Gray, Byte>(), des);
                        CvInvoke.cvThreshold(des, thres, 20, 255, THRESH.CV_THRESH_BINARY);
                        CvInvoke.cvErode(thres, eroded, IntPtr.Zero, 2);
                      }
        
                   }
    
     private void StartButton_Click(object sender, EventArgs e)
            {
                Application.Idle += new EventHandler(Tracking);
            }
    
     private void Stopbutton_Click(object sender, EventArgs e)
            {
                Application.Idle -= new EventHandler(Tracking);
            }
