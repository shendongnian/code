     var Update = context.UpdateTables.Find(id);
            Update.Title = title;
            // Mark as Changed
            context.Entry(Update).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
