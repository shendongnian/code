    public class Program
    {
        private static void Main(string[] args)
        {
            var p = new Program();
            p.PingPong();
            Console.ReadLine();
        }
        private void PingPong()
        {
             var ips = new List<string>()
                {
                    "43.128.240.28",
                    "159.203.123.166",
                    ... 30 in total in this test ...
                    "201.131.43.87",
                    "108.232.183.145"
                };
            foreach (var ip in ips)
            {
                string ip1 = ip;
                Task.Factory.StartNew(async () =>
                    {
                        var newtwork = new Network();
                        var start = DateTime.Now;
                        string ping = newtwork.Pinger(ip1);
                        Console.WriteLine("{0} - {1} - {2}ms", ip, ping, (DateTime.Now - start).TotalMilliseconds);
                    });
            }
        }
    }
