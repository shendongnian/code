        public static void MergeObject<T>(this DataContext dc, T modifiedItem)
        {
            MergeObjectGraph<T>(dc, new List<T>() { modifiedItem });
        }
        public static void MergeObjectGraph<T>(this DataContext dc, IEnumerable<T> modifiedCollection)
        {
            var existingItems = dc.Set<T>.AsNoTracking().ToList();
            var addedItems = modifiedCollection.Except(existingItems, x => x.Id).ToList();
            var deletedItems = existingItems.Except(modifiedCollection, x => x.Id);
            addedItems.ToList().ForEach(tchr => dc.Entry(tchr).State = EntityState.Added);
            deletedItems.ToList().ForEach(tchr => dc.Entry(tchr).State = EntityState.Deleted);
            foreach (var item in modifiedCollection)
            {
                var navigationProperties = profile.GetType().GetProperties().Where(p => p.PropertyType.Equals(YourBaseType)).ToList();
                var nestedCollections = profile.GetType().GetProperties().Where(p => p.IsGenereicType && p.GetGenericTypeDefinition() == typeof(ICollection<>));
                foreach (var navProp in navigationProperties)
                {
                    var p = navProp.GetValue(item,null);
                    dc.MergeObject(navProp); //need to call this by reflection
                }
                foreach (var nested in nestedCollections)
                {
                    var coll = nested.GetValue(item,null);
                    dc.MergeObjectGraph(coll); //need to call this by reflection
                }
                var entity = dc.Set<T>.Find(item.Id);
                if (entity == null)
                    continue;
                var entry = dc.Entry(entity);
                entry.CurrentValues.SetValues(item);
            }
        }
