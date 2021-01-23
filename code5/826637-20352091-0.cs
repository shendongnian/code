    public static Dictionary<string, int> lstVMStats()
    {
        ITAPP.Models.DBEntities db = new ITAPP.Models.DBEntities();
        var varESxis = from d in db.tblVirtualServers 
                       group d by d.ESXiID into g 
                       orderby g.Count() descending, g.Key 
                       select new {
                         ESXi = g.Key,
                         Count = g.Count() 
                       };
        return varESxis.ToDictionary(x=>x.Key, y=>y.Value);
    }
