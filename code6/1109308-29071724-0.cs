    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV.UI;
    using Emgu.CV.Features2D;
    using Emgu.CV.Util;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {//Set the name of pop-up window
            String winname = "First Window";
            Timer My_Time = new Timer();
            int FPS = 30;
            Capture _capture;
    
            public Form1()
            {
                InitializeComponent();
    
                //Frame Rate
                My_Time.Interval = 1000 / FPS;
                My_Time.Tick += new EventHandler(My_Timer_Tick);
                My_Time.Start();
    
                _capture = new Capture("A.avi");   // Error this line
    
            }
    
            private void My_Timer_Tick(object sender, EventArgs e)
            {
                imageBox.Image = _capture.QueryFrame();
            }
        }
    }
