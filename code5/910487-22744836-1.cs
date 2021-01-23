    public void ViewEntity(MyEntity entity) // Want to read properties of my entity
    {
        using (var Db = new MyDbContext()) 
        {
           var DummyList = Db.MyEntities.ToList(); // Iteration on this DbSet
           // Set the Modified state of entity or you can write defensive code 
           // to check it before set the state.
           if (Db.Entry(entity).State == EntityState.Modified) {
              Db.Entry(entity).State = EntityState.Modified
           }
 
           // Attached it
           Db.MyEntities.Attach(Entity);
           
           Db.SaveChanges();
        }
    }
