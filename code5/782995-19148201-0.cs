    using (DBContext context = new DBContext())
    {
        myCollection = context.Items.Where(i => i.Type == 1)
           .AsEnumerable().OrderBy(k => k.Name).Select(w => new
            {
                Alias = w.Name + string.Format("{0}", w.Id),
                Name = w.Name                        
            }).ToArray();
    }
