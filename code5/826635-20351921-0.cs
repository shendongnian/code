    class VirtualServerInfo
    {
        public string ESXi { get; set; }
        public int Count { get; set; }
    }
    public static List<VirtualServerInfo> lstVMStats()
    {
        ITAPP.Models.DBEntities db = new ITAPP.Models.DBEntities();
        var varESxis = from d in db.tblVirtualServers 
                       group d by d.ESXiID into g 
                       orderby g.Count() descending, g.Key 
                       select new VirtualServerInfo{
                        ESXi = g.Key,
                        Count = g.Count() 
                       };
        return varESxis.ToList();
    }
