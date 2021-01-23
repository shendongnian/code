    var entry = context.Entry(foo);
    if (entry.State == EntityState.Detached)
        context.Set<FooType>().Attach(entity);
    entry.Property(e => e.ByteProperty).IsModified = true;
        
    // Or this if your version of EF doesn't support the lambda version:
    // entry.Property("ByteProperty").IsModified = true;
