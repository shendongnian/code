    MyEntity entity = new MyEntity();
    MyEntity.Name = "HELLO WORLD";
    entity = MyService.Add(entity);
    
    MyEntity otherEntity = MyService.Get(123);
    otherEntity.OtherProperty = entity;		// Assuming you have a navigation property
    MyService.Update(otherEntity);
    
    uow.Commit();
