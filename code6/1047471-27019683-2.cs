    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    
    namespace recursion
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
    
            System.Threading.Thread thread;
    
            protected override void OnStart(string[] args)
            {
                System.IO.File.WriteAllText(@"C:\Temp\Foo.txt", "Starting at: " + System.DateTime.Now.ToString());
                thread = new System.Threading.Thread(DoSomething);
                thread.Name = "Worker Thread";
                thread.IsBackground = true;
                thread.Start();
            }
    
            private void DoSomething() {
                while (true)
                {
                    System.IO.File.WriteAllText(@"C:\Temp\Foo.txt", "The Time is now: " + System.DateTime.Now.ToString());
                    System.Threading.Thread.Sleep(1000);
                }
            }
    
            protected override void OnStop()
            {
            }
        }
    }
