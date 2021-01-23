    ApplicationDbContext : DbContext
        {
                   public override int SaveChanges()
                      {
                      //sets child in ram memory  entity state to modified 
                      //if its parent entity state is modified each time you call SaveChanges()
                      Child.Local.Where(r => Entry(r.Parent).State == EntityState.Modified)
                     .ToList().ForEach(r => Entry(r).State=EntityState.Modified);
                      
                      base.SaveChanges();
                      }
       }
