    using (EntityConnection con = new EntityConnection("Name = testEntities"))
    {
        con.Open();
        using (testEntities db = new testEntities())
        {
            int yilim = 2013;
            IQueryable<Model> models = (db.Model.Where(p => p.Date.Year == yilim)
                                                .Where(p => p.ID == 2 || p.ID == 3)
                                                .OrderBy(m => m.Date.Month))
                                                .AsQueryable();
            string modelsQuery = ((System.Data.Objects.ObjectQuery)models).ToTraceString();
            IQueryable<Model> models2 = (db.Model.Where(p => p.Date.Year == yilim && 
                                                            (p.ID == 2 || p.ID == 3))
                                                 .OrderBy(m => m.Date.Month))
                                                 .AsQueryable();
            string modelsQuery2 = ((System.Data.Objects.ObjectQuery)models2).ToTraceString();
            System.IO.File.WriteAllText(@"C:\Users\username\Desktop\queries.txt", 
                "Query 1:\r\n" + modelsQuery + "\r\n" + 
                "Query 2:\r\n" + modelsQuery2);
                
        }
