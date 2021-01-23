     public class Ip4RouteEntry
    {
        public IPAddress DestinationIP { get; set; }
        public IPAddress SubnetMask { get; set; }
        public IPAddress GatewayIP { get; set; }
        public int InterfaceIndex { get; set; }
        public int ForwardType { get; set; }
        public int ForwardProtocol { get; set; }
        public int ForwardAge { get; set; }
        public int Metric { get; set; }
    }
    
        public static void RoutePrint()
        {
            List<Ip4RouteEntry> routeTable = GetRouteTable();
            RoutePrint(routeTable);
        }
        public static void RoutePrint(List<Ip4RouteEntry> routeTable)
        {
            Console.WriteLine("Route Count: {0}", routeTable.Count);
            Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", "DestinationIP", "NetMask", "Gateway", "IF", "Metric");
            foreach (Ip4RouteEntry entry in routeTable)
            {
                Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", entry.DestinationIP, entry.SubnetMask, entry.GatewayIP, entry.InterfaceIndex, entry.Metric);
            }
        }
        public static List<Ip4RouteEntry> GetRouteTable()
        {
            var fwdTable = IntPtr.Zero;
            int size = 0;
            var result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            fwdTable = Marshal.AllocHGlobal(size);
            result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            var forwardTable = ReadIPForwardTable(fwdTable);
            Marshal.FreeHGlobal(fwdTable);
            List<Ip4RouteEntry> routeTable = new List<Ip4RouteEntry>();
            for (int i = 0; i < forwardTable.Table.Length; ++i)
            {
                Ip4RouteEntry entry = new Ip4RouteEntry();
                entry.DestinationIP = new IPAddress((long)forwardTable.Table[i].dwForwardDest);
                entry.SubnetMask = new IPAddress((long)forwardTable.Table[i].dwForwardMask);
                entry.GatewayIP = new IPAddress((long)forwardTable.Table[i].dwForwardNextHop);
                entry.InterfaceIndex = Convert.ToInt32(forwardTable.Table[i].dwForwardIfIndex);
                entry.ForwardType = Convert.ToInt32(forwardTable.Table[i].dwForwardType);
                entry.ForwardProtocol = Convert.ToInt32(forwardTable.Table[i].dwForwardProto);
                entry.ForwardAge = Convert.ToInt32(forwardTable.Table[i].dwForwardAge);
                entry.Metric = Convert.ToInt32(forwardTable.Table[i].dwForwardMetric1);
                routeTable.Add(entry);
            }
            return routeTable;
        }
        public static bool RouteExists(string destinationIP)
        {
            List<Ip4RouteEntry> routeTable = Ip4RouteTable.GetRouteTable();
            Ip4RouteEntry routeEntry = routeTable.Find(i => i.DestinationIP.ToString().Equals(destinationIP));
            return (routeEntry != null);
        }
        public static List<Ip4RouteEntry> GetRouteEntry(string destinationIP)
        {
            List<Ip4RouteEntry> routeTable = Ip4RouteTable.GetRouteTable();
            List<Ip4RouteEntry> routeMatches = routeTable.FindAll(i => i.DestinationIP.ToString().Equals(destinationIP));
            return routeMatches;
        }
        public static List<Ip4RouteEntry> GetRouteEntry(string destinationIP, string mask)
        {
            List<Ip4RouteEntry> routeTable = Ip4RouteTable.GetRouteTable();
            List<Ip4RouteEntry> routeMatches = routeTable.FindAll(i => i.DestinationIP.ToString().Equals(destinationIP) && i.SubnetMask.ToString().Equals(mask));
            return routeMatches;
        }
        public static void CreateRoute(Ip4RouteEntry routeEntry)
        {
            var route = new PMIB_IPFORWARDROW
            {
                dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.DestinationIP.ToString()).GetAddressBytes(), 0),
                dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.SubnetMask.ToString()).GetAddressBytes(), 0),
                dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.GatewayIP.ToString()).GetAddressBytes(), 0),
                dwForwardMetric1 = 99,
                dwForwardType = Convert.ToUInt32(3), //Default to 3
                dwForwardProto = Convert.ToUInt32(3), //Default to 3
                dwForwardAge = 0,
                dwForwardIfIndex = Convert.ToUInt32(routeEntry.InterfaceIndex)
            };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PMIB_IPFORWARDROW)));
            try
            {
                Marshal.StructureToPtr(route, ptr, false);
                var status = NativeMethods.CreateIpForwardEntry(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void CreateRoute(string destination, string mask, int interfaceIndex, int metric)
        {
            NetworkAdaptor adaptor = NicInterface.GetNetworkAdaptor(interfaceIndex);
            var route = new PMIB_IPFORWARDROW
            {
                dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(destination).GetAddressBytes(), 0),
                dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(mask).GetAddressBytes(), 0),
                dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(adaptor.PrimaryGateway.ToString()).GetAddressBytes(), 0),
                dwForwardMetric1 = Convert.ToUInt32(metric),
                dwForwardType = Convert.ToUInt32(3), //Default to 3
                dwForwardProto = Convert.ToUInt32(3), //Default to 3
                dwForwardAge = 0,
                dwForwardIfIndex = Convert.ToUInt32(interfaceIndex)
            };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PMIB_IPFORWARDROW)));
            try
            {
                Marshal.StructureToPtr(route, ptr, false);
                var status = NativeMethods.CreateIpForwardEntry(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void DeleteRoute(Ip4RouteEntry routeEntry)
        {
            var route = new PMIB_IPFORWARDROW
            {
                dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.DestinationIP.ToString()).GetAddressBytes(), 0),
                dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.SubnetMask.ToString()).GetAddressBytes(), 0),
                dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.GatewayIP.ToString()).GetAddressBytes(), 0),
                dwForwardMetric1 = 99,
                dwForwardType = Convert.ToUInt32(3), //Default to 3
                dwForwardProto = Convert.ToUInt32(3), //Default to 3
                dwForwardAge = 0,
                dwForwardIfIndex = Convert.ToUInt32(routeEntry.InterfaceIndex)
            };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PMIB_IPFORWARDROW)));
            try
            {
                Marshal.StructureToPtr(route, ptr, false);
                var status = NativeMethods.DeleteIpForwardEntry(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void DeleteRoute(string destinationIP)
        {
            List<Ip4RouteEntry> routeMatches = Ip4RouteTable.GetRouteEntry(destinationIP);
            if (routeMatches == null) return;
            foreach (Ip4RouteEntry routeEntry in routeMatches)
            {
                DeleteRoute(routeEntry);
            }
        }
        public static void DeleteRoute(string destinationIP, string mask)
        {
            List<Ip4RouteEntry> routeMatches = Ip4RouteTable.GetRouteEntry(destinationIP, mask);
            if (routeMatches == null) return;
            foreach (Ip4RouteEntry routeEntry in routeMatches)
            {
                DeleteRoute(routeEntry);
            }
        }
        public static void DeleteRoute(int interfaceIndex)
        {
            var fwdTable = IntPtr.Zero;
            int size = 0;
            var result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            fwdTable = Marshal.AllocHGlobal(size);
            result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            var forwardTable = ReadIPForwardTable(fwdTable);
            Marshal.FreeHGlobal(fwdTable);
            List<PMIB_IPFORWARDROW> filtered = new List<PMIB_IPFORWARDROW>();
            for (int i = 0; i < forwardTable.Table.Length; ++i)
            {
                if (Convert.ToInt32(forwardTable.Table[i].dwForwardIfIndex).Equals(interfaceIndex))
                {
                    filtered.Add(forwardTable.Table[i]);
                }
            }
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PMIB_IPFORWARDROW)));
            try
            {
                foreach (PMIB_IPFORWARDROW routeEntry in filtered)
                {
                    Marshal.StructureToPtr(routeEntry, ptr, false);
                    var status = NativeMethods.DeleteIpForwardEntry(ptr);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
 
