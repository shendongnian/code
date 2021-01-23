    class getIP
    {
        public getIP()
        {
            IPAddress ip = Dns.GetHostEntry("whybla01").AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
            Console.WriteLine(ip);
        }
    }
