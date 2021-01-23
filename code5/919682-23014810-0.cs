    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceProcess;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName.Equals("MyServiceNameHere"));
                if (sc != null)
                {
                    if (sc.Status.Equals(ServiceControllerStatus.Running))
                    {
                        sc.Stop();
                        Process[] procs = Process.GetProcessesByName("MyProcessName");
                        if (procs.Length > 0)
                        {
                            foreach (Process proc in procs)
                            {
                                //do other stuff if you need to find out if this is the correct proc instance if you have more than one
                                proc.Kill();
                            }
                        }
                    }
                }
            }
        }
    }
