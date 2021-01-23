      var entities = (from entity in data.OfType<Company>()
                      select new EntityBaseInfo { Name = entity.CompanyName, EntityBase = entity }
                     )
                     .Union
                     (from entity in data.OfType<Person>()
                      select new EntityBaseInfo { Name = entity.FirstName + " " + entity.LastName, EntityBase = entity }
                     );
      var orderedEntities = entities.OrderBy(item => item.Name).Select(item => item.EntityBase);
