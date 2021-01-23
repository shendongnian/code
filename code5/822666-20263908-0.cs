    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
    
            private System.Threading.AutoResetEvent are = new System.Threading.AutoResetEvent(false);
    
            protected override void OnStart(string[] args)
            {
                new System.Threading.Thread(mt) { IsBackground = true }.Start();
            }
    
            private void mt()
            {
                // Set up timer here
    
                // wait for OnStop indefinitely
                are.WaitOne();
            }
    
            protected override void OnStop()
            {
                are.Set();
            }
        }
    }
