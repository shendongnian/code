    Mapper.Initialize(cfg => {
      cfg.CreateMap<ICrmBusinessObject, Entity>()
        .AfterMap((crmEntity, entity) =>
        {
          var type = crmEntity.GetType();
          var propertyDict = type.GetProperties()
            .Select(x => new KeyValuePair<string, object>(x.Name.ToLowerInvariant(),
              x.GetValue(crmEntity)));
          foreach (var prop in propertyDict)
          {
            entity[prop.Key] = prop.Value;
          }
        });
    });
