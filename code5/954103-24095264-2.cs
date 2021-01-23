    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Input;
    using yournamespace.Forms;
    using System.IO;
    
    namespace yourNameSpace
    {
       
        public partial class frmMain : Form
        {
            
            public frmMain()
            {
                InitializeComponent();
           
            }
       
            string AbsoluteRef = null;
         
            private void frmMain_Load(object sender, EventArgs e)
            {
    
            if (System.Diagnostics.Debugger.IsAttached)
            {
                AbsoluteRef = Path.GetFullPath(Application.StartupPath + "\\..\\..\\Resources\\");
            }
            else
            {
                AbsoluteRef = Application.StartupPath + "\\Resources\\";
            }
            string vlcVideo = AbsoluteRef + "myvideo.mp4";
            axVLC.playlist.add(vlcvideo);
    
            }
