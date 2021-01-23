        static void Main(string[] args)
        {
            PhysicalAddress pa = LocateMacAddress(IPAddress.Parse("172.16.0.99"));
            Console.WriteLine(pa.ToString());
            Console.ReadKey();
        }
        static PhysicalAddress LocateMacAddress(IPAddress ipAddress)
        {
            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] macAddressBytes = new byte[6];
                int length = macAddressBytes.Length;
                ArpErrorCodes c = (ArpErrorCodes)SendARP((uint)ipAddress.Address, 0, macAddressBytes, ref length);
                if (c == ArpErrorCodes.None)
                {
                    return new PhysicalAddress(macAddressBytes);
                }
            }
            return PhysicalAddress.None;
        }
    
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(uint DestIP, uint SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
    
    }
    
    enum ArpErrorCodes
    {
        None = 0,
        ERROR_GEN_FAILURE = 31,
        ERROR_NOT_SUPPORTED = 50,
        ERROR_BAD_NET_NAME = 67,
        ERROR_BUFFER_OVERFLOW = 111,
        ERROR_NOT_FOUND = 1168,
        ERROR_INVALID_USER_BUFFER = 1784,
    }
