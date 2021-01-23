        public static IList<Resources> GetSwapResources(string resourceID)
        {
            //selected resource
            var res = db.Resources.FirstOrDefault(p => p.ResourceID == resourceID);
           
            //select all active resources excluding selected
            var resources = db.Resources.Where(p => p.Active == true && p.ResourceID != resourceID);
     .Where(a => a.CapM3 <= res.CapM3 && a.CapMT <= res.CapMT && a.CapUD<= res.CapUD);            
           
            return resources.ToList();
        }
    } 
