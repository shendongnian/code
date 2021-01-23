    public void ViewEntity(MyEntity entity) // Want to read properties of my entity
    {
        using (var Db = new MyDbContext()) 
        {
           var DummyList = Db.MyEntities.ToList(); // Iteration on this DbSet
           // Set the state of entity 
           Db.Entry(entity).State = EntityState.Modified
           
           // Attached it
           Db.MyEntities.Attach(Entity);
           
           Db.SaveChanges();
        }
    }
