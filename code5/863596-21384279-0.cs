    var entry = context.Entry(foo);
    if (entry.State == EntityState.Detached)
    {
        context.Set<FooType>().Attach(entity);
        entry.Property(e => e.ByteProperty).IsModified = true;
    }
