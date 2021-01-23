    using (var context = new SomeEntityContext())
    {
       context.Configuration.LazyLoadingEnabled = false; // This is the fixer.
       return context.SomeEntitiesWithRelations.ToList();
    }
