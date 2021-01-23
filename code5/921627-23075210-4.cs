    from myEntity in dbContext.MyEntities
    join myOtherEntity in dbContext.MyOtherEntities on myEntity.Id equals myOtherEntity.MyEntityId
    join oneMoreEntity in dbContext.OneMoreEntities on myEntity.Id equals oneMoreEntity.MyEntityId
    select new {
        myEntity.Id,
        myEntity.Name,
        myOtherEntity.OtherProperty,
        oneMoreEntity.OneMoreProperty
    }
