    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using System.IO;
    using System.Timers;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
     
     
    namespace trail2zip
    {
        public partial class trail2zip : ServiceBase
        {
            Timer timer;
            string path1 = @"E:\zipped files\New Text Document.txt";
            string path2 = @"E:\output\filezipname.zip";
            string path3 = @"E:\zipped files\R_23122015.txt";
     
     
            int timerInterval = 60000;
     
            public trail2zip()
            {
                InitializeComponent();
                timer = new Timer();
                timer.Elapsed+=new ElapsedEventHandler(this.timer_Elapsed);
                timer.Interval = timerInterval;
                timer.Enabled = true;
     
            }
     
            protected override void OnStart(string[] args)
            {
                timer.Start();
            }
     
            protected override void OnStop()
            {
                timer.Stop();
                timer.SynchronizingObject = null;
                timer.Elapsed -= new ElapsedEventHandler(this.timer_Elapsed);
                timer.Dispose();
                timer = null;
     
     
            }
            public void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
     
                ZipFile z = ZipFile.Create(path2);       //(filezipname);
                z.BeginUpdate();
                z.Add(path1);
                z.Add(path3);
                z.CommitUpdate();
                z.Close();
     
     
            }
        }
    }
