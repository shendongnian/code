    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Can build your list of IPs using a for loop
                List<IPAddress> ips = new List<IPAddress>
                {
                    new IPAddress(new byte[] {192, 168, 0, 1}),
                    new IPAddress(new byte[] {192, 168, 0, 2}),
                    // More ips in this list.
                };
                // Exactly what do you do with initiated tasks will depend on your specific scenario.
                List<Task> tps = new List<Task>();
                foreach(var ip in ips)
                {
                    tps.Add(InitiatePing(ip));
                }
                // Needed so that console app doesn't exit..
                Console.ReadLine();
            }
            private static async Task InitiatePing(IPAddress ip)
            {
                // Note, this API is different from SendAsync API you are using
                // You may also want to reuse Ping instance instead of creating new one each time.
                var result = await new Ping().SendPingAsync(ip);
                // Process your result here, however you want.
                Console.WriteLine(result.Address + "-" + result.Status + "-" + result.RoundtripTime);
            }
        }
    }
