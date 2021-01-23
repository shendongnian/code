    from myEntity in dbContext.MyEntities
    join myOtherEntity in dbContext.MyOtherEntities
    on myEntity.Id equals myOtherEntity.MyEntityId
    select new {
        myEntity.Name,
        myOtherEntity.OtherProperty
    }
