    IEnumerable<ARPTABLE> GetARPTable()
        {
            IpTable arp = new IpTable();
            IEnumerable<ARPTABLE> arptable = arp.GetArpTable();
    
            arptable = arptable.Select(i =>
            {
                Device device = DeviceTable.SingleOrDefault(j => j.PhysicalAddress == i.MAC);
                
                if (device != null)
                {
                    i.Description = device.Model ?? device.DeviceName;
                }
                
                return i;
            });
    
            return arptable;
    
        }
