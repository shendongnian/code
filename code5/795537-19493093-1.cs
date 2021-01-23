    public List<State> GetAllStates()
        {
            List<State> p;
            p = (from a in _db.ProductImageMaps
                 where a.State != "" && a.State != null
                 select new State
                 {
                     Name = a.State
                 }).Distinct().OrderBy(a=>a.Name).ToList();
            return p;
    
        }
