    using (var ctx = new Dal.MyEntities())
    {
        try
        {
            //...
            Dal.TempTable temp = new Dal.TempTable();
            //...
            ctx.TempTables.Add(temp);
            // some query that joins on the temp table...
            if (no
            results are 
            returned)
            {
                throw new Exception("no results") 
            }
            // Normal processing and return result
        }
        catch
        {
            ctx.TempTables.Remove(temp);
            ctx.SaveChanges();
        }
        finally
        {
            if (temp != null && temp.ID != 0)
            {
                ctx.TempTables.Remove(temp);
                ctx.SaveChanges();
            }
        }
    }
