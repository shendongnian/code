    public static Object GetObject(this Dictionary<string, object> dict, Type type)
        {
            var obj = Activator.CreateInstance(type);
    
            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if(prop == null) continue;
                object value = kv.Value;
                if (value is Dictionary<string, object>)
                {
                    value = GetObject((Dictionary<string, object>) value, prop.PropertyType); // <= This line
                }
    
                prop.SetValue(obj, value, null);
            }
            return obj;
        }
