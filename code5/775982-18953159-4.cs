    EFRepository<BaseEntity> baseRepository = new EFRepository<BaseEntity>(new MyContext ());
            
            List<BaseEntity> entities = new List<BaseEntity>()
            {
                new Entity1()
                {
                    BaseEntityProp1 = "Entity1Prop1",
                    BaseEntityProp2 = "Entity1Prop2",
                },
                new Entity2()
                {
                    BaseEntityProp1 = "Entity2Prop1",
                    BaseEntityProp2 = "Entity2Prop2",
                }
            };
            foreach (var entity in entities)
            {
                baseRepository.Insert(entity);
            }
            baseRepository.Commit();
