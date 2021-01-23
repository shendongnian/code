    (this as IObjectContextAdapter).ObjectContext.ObjectMaterialized +=
        delegate(Object sender, ObjectMaterializedEventArgs e)
        {
            if (e.Entity is Entity)
            {
                var entityType = e.Entity.GetType();
                IEnumerable<PropertyInfo> collectionProperties;
                if (!CollectionPropertiesPerType.TryGetValue(entityType, out collectionProperties))
                {
                    CollectionPropertiesPerType[entityType] = (collectionProperties = entityType.GetProperties()
                        .Where(p => p.PropertyType.IsGenericType && typeof(ICollection<>) == p.PropertyType.GetGenericTypeDefinition()));
                }
                foreach (var collectionProperty in collectionProperties)
                {
                    var collectionType = typeof(FilteredCollection<>).MakeGenericType(collectionProperty.PropertyType.GetGenericArguments());
                    DbCollectionEntry dbCollectionEntry = Entry(e.Entity).Collection(collectionProperty.Name);
                    dbCollectionEntry.CurrentValue = Activator.CreateInstance(collectionType, new[] { dbCollectionEntry.CurrentValue, dbCollectionEntry });
                }
            }
        };
