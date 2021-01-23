    Entity e = new Entity();
    ForeignEntity fe = context.Find(...);
    fe.Entity = e;
    context.Entry(fe).State = EntityState.Modified;
    context.SaveChanges();
