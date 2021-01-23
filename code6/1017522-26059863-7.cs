    var entity = new MyEntity();
    entity = mydbcontext.Add(entity);
    
    var otherEntity = mydbcontext.MyEntities.Single(z => z.ID == 123);
    otherEntity.OtherProperty = entity;		// Assuming you have a navigation property
    
    uow.Commit();
