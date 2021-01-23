    public abstract class Entity
    {
      public int MyCompare(Entity entity)
      {
       ..
       ..
      }
    }
    private Entity Exists(Entity entity)
    {
        return Context.DbSet<Entity>.FirstOrDefult(i => i.MyCompare(entity) == 0);
    }
