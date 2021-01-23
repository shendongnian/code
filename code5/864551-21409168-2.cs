    using LibraryData;
    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.Threading.Tasks;
    
    namespace SandboxConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                var connectionName = Guid.NewGuid().ToString();
                ProcessStartInfo info = new ProcessStartInfo("HostApp", connectionName);
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
    
                var proxyApp = Process.Start(info);
    
                //Blocks till "Service has started and is ready to use." is printed.
                proxyApp.StandardOutput.ReadLine();
    
                var sapProxyFactory = new ChannelFactory<ISapProxy>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/" + connectionName));
                Task.Factory.StartNew(() =>
                {
                    var sapProxy = sapProxyFactory.CreateChannel();
                    
                    try
                    {
                        var result = sapProxy.QueryData("Some query");
    
                        //Do somthing with the result;
                    }
                    finally
                    {
                        sapProxy.Close();
                    }
                });
    
                Console.WriteLine("ready");
                //If you hit enter here before the 5 second pause in the library is done it will kill the hosting process forcefully "canceling" the operation.
                Console.ReadLine();
    
                proxyApp.Kill();
    
                Console.ReadLine();
    
            }
        }
    }
