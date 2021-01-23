    public static T CopyObjectFromExpando<T>(this object s) where T : class
            {
                var source = (ExpandoObject)s;
                // Might as well take care of null references early.
                if (source == null)
                {
                    throw new ArgumentNullException("s");
                }
    
                var propertyMap = typeof(T).GetProperties().ToDictionary(p => p.Name.ToLowerInvariant(), p => p);
                var destination = Activator.CreateInstance<T>();
                // By iterating the KeyValuePair<string, object> of
                // source we can avoid manually searching the keys of
                // source as we see in your original code.
                foreach (var kv in source)
                {
                    PropertyInfo p;
                    if (propertyMap.TryGetValue(kv.Key.ToLowerInvariant(), out p))
                    {
                        var propType = p.PropertyType;
                        if (kv.Value == null)
                        {
                            if (!propType.IsNullable() && propType != typeof(string))
                            {
                                // Throw if type is a value type 
                                // but not Nullable<>
                                throw new ArgumentException("not nullable");
                            }
                        }
                        else if (propType.IsEnum)
                        {
                            var enumvalue = Enum.ToObject(propType, kv.Value);
                            p.SetValue(destination, enumvalue, null);
                            continue;
                        }
                        else if (propType == typeof(bool) && kv.Value.GetType() != typeof(bool))
                        {
                            var boolvalue = Convert.ToBoolean(kv.Value);
                            p.SetValue(destination, boolvalue, null);
                            continue;
                        }
                        else if (propType.IsNullable())
                        {
                            var nullType = Nullable.GetUnderlyingType(propType);
                            var value = Convert.ChangeType(kv.Value, nullType);
                            p.SetValue(destination, value, null);
                            continue;
                        }
                        else if (kv.Value.GetType() != propType)
                        {
                            // You could make this a bit less strict 
                            // but I don't recommend it.
                            throw new ArgumentException("type mismatch");
                        }
                        p.SetValue(destination, kv.Value, null);
                    }
                }
    
                return destination;
            }
