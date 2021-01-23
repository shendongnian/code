    public static List<TEntity> DynamicContains<TEntity>(this IEnumerable<TEntity> entities, string propertyName, object item)
        {
            List<TEntity> comparingEntities = new List<TEntity>();
            foreach (var obj in entities)
            {
                var property = obj.GetType().GetProperty(propertyName);
                if (property.PropertyType == typeof(String) && ((string)property.GetValue(obj, new object[] { })).ToLower().Contains(item.ToString().ToLower()))
                    comparingEntities.Add(obj);
                if (property.PropertyType == typeof(Boolean) && ((bool)property.GetValue(obj, new object[] { })) == (bool)item)
                    comparingEntities.Add(obj);     
            }
            return comparingEntities;
        }
