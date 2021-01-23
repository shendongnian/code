    ...
    select new MyJoinedEntity {
        Id = myEntity.Id,
        Name = myEntity.Name,
        OtherProperty = myOtherEntity.OtherProperty,
        OneMoreProperty = oneMoreEntity.OneMoreProperty
    }
