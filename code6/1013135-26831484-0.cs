        public static class RedisUtils
            {
    //Serialize in Redis format:
                public static HashEntry[] ToHashEntries(this object obj)
                {
                    PropertyInfo[] properties = obj.GetType().GetProperties();
                    return properties.Select(property => new HashEntry(property.Name, property.GetValue(obj).ToString())).ToArray();
                }
        //Deserialize from Redis format
                public static T ConvertFromRedis<T>(this HashEntry[] hashEntries)
                {
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    var obj = Activator.CreateInstance(typeof(T));
                    foreach (var property in properties)
                    {
                        HashEntry entry = hashEntries.FirstOrDefault(g => g.Name.ToString().Equals(property.Name));
                        if (entry.Equals(new HashEntry())) continue;
                        property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                    }
                    return (T)obj;
                }
            }
