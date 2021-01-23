    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Net;
    
    using AForge.Video;
    using AForge.Controls;
    using AForge.Video.DirectShow;
    
    namespace AddPanel
    {
        public partial class Form1 : Form
        {
            private string iPadd;
            public string IPadd
            {
                get { return iPadd;}
                set
                {
                    iPadd = value;
                }
            }
            private string usrID;
            public string UsrID
                {
                get { return usrID; }
                set
                {
                    usrID = value;
                }
            }
            private string Pswd;
            public string pswd
            { 
                get{return Pswd;}
                set
                {
                    Pswd = value;
                }
            }
            private string Filename;
            public string filename
            {
                get { return Filename; }
                set
                {
                    Filename = value;
                }
             }
            public Form1()
            {
    
    
                InitializeComponent();
    
    
                DisplayImage();
            }
    
    
            private void DisplayImage()
            {
    
    
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
    
 
                UsrID = "webservice";
                IPadd = "10.108.212.100";
                pswd = "E4emw@tch!ngU";
                WS = fs;
                test nt = new test();
                nt.Location = new System.Drawing.Point(33, h);
                nt.Name = "test1";
                nt.Size = new System.Drawing.Size(408, 266);
                this.Controls.Add(nt);
    
            } 
    
        }
    }
