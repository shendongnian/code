        context.Configuration.AutoDetectChangesEnabled = false;
        int lines = 0;
        int batchSize=50;
        using (StringReader reader = new StringReader(data))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                c = new table1();
                c.Code = line.Substring(0, 5).Trim();
                c.name= line.Substring(5, 18).Trim();
                c.phone= line.Substring(23, 16).Trim();
                c.address = line.Substring(39, 20).Trim();
                context.table1.Add(c);
                if (lines++ % batchSize == 0)
                {
                    context.SaveChanges();
                    context = new DataContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }
        }
        context.SaveChanges();
