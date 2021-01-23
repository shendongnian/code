    class Program
    {
        static void Main(string[] args)
        {// Get my PC IP address
            Console.WriteLine("My IP : {0}", IPHelper.GetIPAddress());
            // Get My PC MAC address
            Console.WriteLine("My MAC: {0}", IPHelper.GetMacAddress());
            // Get all devices on network
            Dictionary<IPAddress, PhysicalAddress> all = IPHelper.GetAllDevicesOnLAN();
            foreach (KeyValuePair<IPAddress, PhysicalAddress> kvp in all)
            {
                Console.WriteLine("IP : {0}\n MAC {1}", kvp.Key, kvp.Value);
            }
            PhysicalAddress ph = PhysicalAddress.Parse("485B39C25E67");
            var ip = IPHelper.GetIPAddress(ph);
            Console.WriteLine("IP is {0}", ip);
        }
    }
