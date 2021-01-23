        private object CloneInternal(object entity, int depth)
        {
            var cloned = Activator.CreateInstance(entity.GetType());
            foreach (var property in cloned.GetType().GetProperties())
            {
                Type propertyType = property.PropertyType;
                if (propertyType.Namespace == "System" && property.CanWrite)
                {
                    property.SetValue(cloned, property.GetValue(entity));
                }
                else if (depth > 0 && property.CanWrite && typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    if (typeof(IList).IsAssignableFrom(propertyType))
                    {
                        var collection = (IList)Activator.CreateInstance(propertyType);
                        var value = property.GetValue(entity);
                        foreach (var element in value as IEnumerable)
                        {
                            collection.Add(CloneInternal(element, depth - 1));
                        }
                        property.SetValue(cloned, collection);
                    }
                    else if (propertyType.IsGenericType)
                    {
                        var type = propertyType.GetGenericArguments().Single();
                        if (typeof(IList<>).MakeGenericType(type).IsAssignableFrom(propertyType) ||
                            typeof(ISet<>).MakeGenericType(type).IsAssignableFrom(propertyType))
                        {
                            var collection = Activator.CreateInstance(propertyType);
                            var addMethod = collection.GetType().GetMethod("Add");
                            var value = property.GetValue(entity);
                            foreach (var element in value as IEnumerable)
                            {
                                addMethod.Invoke(collection, new[] {CloneInternal(element, depth - 1)});
                            }
                            property.SetValue(cloned, collection);
                        }
                    }
                }
            }
            return cloned;
        }
