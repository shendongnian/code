            // we need DbContext vaule
            var db = YOUR_DB_CONTEXT; // assing db context here
            // So we can get ObjectContext instance
            var ctx = ((IObjectContextAdapter) db).ObjectContext;
            // we need some entity to check
            object entity = someYourEntity; // assign your entity here
            // let's get its type
            var type = entity.GetType();
            // helper function to get set name
            Func<Type, ObjectContext, string> getEntitySetByObjectType = (t, context) =>
                {
                    var container =
                        context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
                    var entitySet =
                        container.BaseEntitySets.First(item => item.ElementType.Name.Equals(t.Name));
                    return container.Name + "." + entitySet.Name;
                };
            // go through the entity's properties
            foreach (var prop in type.GetProperties())
            {
                // nav properties which are collections
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericArguments().Any(x => x.Assembly == type.Assembly))
                {
                    var val = (IEnumerable)prop.GetValue(entity);
                    if (val != null)
                    {
                        // get value and check if it is not null
                        string setName = null;
                        // go through collection values
                        foreach (var obj in val)
                        {
                            if (setName == null)
                                setName = getEntitySetByObjectType(obj.GetType(), ctx);
                            // get primary key values
                            var entityKey = ctx.CreateEntityKey(setName, obj);
                            Console.WriteLine(entityKey);
                        }
                    }
                }
                // nav props which are single objects
                else if (prop.PropertyType.Assembly == type.Assembly)
                {
                    // get value and check if it is not null
                    var val = prop.GetValue(entity);
                    if (val != null)
                    {
                        // get primary key values
                        var entityKey = ctx.CreateEntityKey(getEntitySetByObjectType(prop.PropertyType, ctx), val);
                        Console.WriteLine(entityKey);
                    }
                }
            }
