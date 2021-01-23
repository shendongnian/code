      if ((type.IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
                {
                    var dict = data as IDictionary;
                    foreach (dynamic entity in dict)
                    {
                        object key = entity.Key;
                        object value = entity.Value;
    
    
                        ProcessKey(key);
                        ProcessVal(value);
                    }
                }
