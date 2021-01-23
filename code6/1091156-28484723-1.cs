    static IQueryable<EntityC> MapEntityC(IQueryable<EntityBandA> query)
    {
      var query = from e in query
                  select new EntityC()
                  {
                    ID = e.EntityA.ID + e.EntityB,
                    StringValue = e.EntityA.StringValue,
                    IntValue = e.EntityB != null ? entityB.IntValue : int.MinValue
                };
      return query;
    }
