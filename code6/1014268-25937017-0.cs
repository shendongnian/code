    BsonClassMap.RegisterClassMap<i_YourModel>(cm =>
     {
      cm.AutoMap();
      cm.SetIdMember(cm.GetMemberMap(x => x.Id)
        .SetIdGenerator(StringObjectIdGenerator.Instance));
     }
    );
