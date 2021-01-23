    //Program.cs
    using LibraryData;
    using System;
    using System.ServiceModel;
    using System.Windows.Forms;
    
    namespace HostApp
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                System.Diagnostics.Debugger.Launch();
                if (args.Length > 0)
                {
                    var uri = new Uri("net.pipe://localhost");
                    using (var host = new ServiceHost(typeof(SapProxy), uri))
                    {
                        //If a client connection fails, shutdown.
                        host.Faulted += (obj, arg) => Application.Exit();
    
                        host.AddServiceEndpoint(typeof(ISapProxy), new NetNamedPipeBinding(), args[0]);
                        host.Open();
                        Console.WriteLine("Service has started and is ready to use.");
    
                        //Start a message loop in the event the service proxy needs one.
                        Application.Run();
    
                        host.Close();
                    }
                }
            }
        }
    }
