    Entity e = new Entity();
    ForeignEntity fe = context.Find(...);
    //Only needed if 'fe' was untracked
    //context.Entry(fe).State = EntityState.Modified; 
    fe.Entity = e;
    context.SaveChanges();
