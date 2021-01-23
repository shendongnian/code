    MyEntity entity = new MyEntity();
    MyEntity.Name = "HELLO WORLD";
    entity = MyService.Add(entity);
    // what should I put here?
    MyEntity otherEntity = MyService.Get(123);
    otherEntity.OtherPropertyId = entity.Id;
    MyService.Update(otherEntity);
    
    uow.Commit();
