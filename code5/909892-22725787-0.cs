    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                int delay = 1000;
                Ping ping = new Ping();
                //OP using something else?
                System.Net.IPAddress h = IPAddress.Parse("8.8.8.8");
    
                while (true)
                {
                    System.Threading.Thread.Sleep(delay);
                    var builder = new StringBuilder();
                         
                        //change buffer size change the result...
                        //var buffer = new byte[65500];
                        var buffer = new byte[32];
                        var reply = ping.Send(h, 1000, buffer, new PingOptions(600, false));
                        var error = reply.Status != IPStatus.Success || reply.RoundtripTime > 3000;
    
                        if (error)
                        {
                            builder.AppendFormat("{0}: {1} ({2}ms)", h, reply.Status, reply.RoundtripTime);
                            builder.Append(Environment.NewLine);
                        }
                        else
                        {
                            builder.AppendFormat("{0}: {1} ({2}ms)", h, reply.Status, reply.RoundtripTime);
                        }
    
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(builder.ToString());
                }
            }
        }
    }
----------
    var reply = ping.Send(h, 1000, buffer, new PingOptions(600, false));
