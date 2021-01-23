    protected override void AfterSaveEntities(Dictionary<Type, List<EntityInfo>> saveMap, List<KeyMapping> keyMappings)
    {
        foreach (var item in saveMap)
        {
            foreach (var entityItem in item.Value)
            {
                if (entityItem.Entity.GetType() == typeof (Foo))
                {
                    var entity = entityItem.Entity as Foo;
                    foreach (var keyMapping in keyMappings)
                    {
                        // Assuming your id is an int
                        if (entity != null && keyMapping.EntityTypeName == entity.GetType().ToString() && entity.Id < 0 && entity.Id == (int) keyMapping.RealValue)
                        {
                            // Get the new Foo from the database context
                            var foo = Context.Foos.First(f => f.FooName == entity.FooName);
                            // Move the temp to where it should be
                            // and get the real from the database
                            keyMapping.TempValue = keyMapping.RealValue;
                            keyMapping.RealValue = foo.Id;
                            entity.Id = foo.Id;
                        }
                    }
                }
            }
        }
        base.AfterSaveEntities(saveMap, keyMappings);
    }
