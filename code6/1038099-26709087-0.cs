    IEnumerable<ARPTABLE> GetARPTable()
    {
        IpTable arp = new IpTable();
        IEnumerable<ARPTABLE> arptable = arp.GetArpTable();
        foreach (var i in arptable)
        {
            Device j = DeviceTable.FirstOrDefault(j => j.PhysicalAddress == i.MAC);
            if (j != null)
            {
                i.Description = j.Model ?? j.DeviceName;
            }
        }
        return arptable;
    }
