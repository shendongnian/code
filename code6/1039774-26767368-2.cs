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
                // Pick your long list of ip address
                List<IPAddress> ips = new List<IPAddress>
                {
                    new IPAddress(new byte[] {127, 0, 0, 1}),
                    new IPAddress(new byte[] {198, 252, 206, 16}),
                    new IPAddress(new byte[] {74, 125, 129, 99}),
                    // Add more ips as you like
                };
                // Exactly what do you do with initiated tasks will depend on your specific scenario.
                List<Task> tps = new List<Task>();
                foreach(var ip in ips)
                {
                    // Delay could vary by IP, but I am hardcoding 10s here.
                    tps.Add(InitiatePings(ip, 10000));
                }
                // Needed so that console app doesn't exit..
                Console.ReadLine();
            }
            private static async Task InitiatePings(IPAddress ip, int delay)
            {
                while (true)
                {
                    // Note, this API is different from SendAsync API you are using
                    // You may also want to reuse Ping instance instead of creating new one each time.
                    var result = await new Ping().SendPingAsync(ip);
                    // Process your result here, however you want.
                    Console.WriteLine(result.Address + "-" + result.Status + "-" + result.RoundtripTime);
                    // Assumes that the delay is not absolute, but time between ping, result processing and next ping.
                    await Task.Delay(delay);
                }
            }
        }
    }
