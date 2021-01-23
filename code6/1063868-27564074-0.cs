    public Foo AddObject(Foo entity)
    {
        entity = UpdateGraph(entity);
        _context.SaveChanges();
        return entity;
    }
    
    public override Foo UpdateGraph(Foo entity)
    {
        return DataContext.UpdateGraph(entity, map => map
            .AssociatedCollection(e => e.Bars)
            .AssociatedEntity(e => e.Baz)
        );
    }
