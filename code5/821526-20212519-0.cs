     public class MyContext: DbContext
     {
        //db sets defined
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<PrimaryKeyTable>().HasMany(x => x.ChildTableCollection).WithRequired(x => 
            Key).WillCascadeOnDelete(false);
              
            //In your case
           
             modelBuilder.Entity<Bunk>().HasMany(x => x.Bookings).WithRequired(x => 
             x.BunkId).WillCascadeOnDelete(false);
         
            // same for room if required.
        }
    }
