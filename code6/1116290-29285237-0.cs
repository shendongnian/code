     public static object GetPropertyValue(object obj, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return obj;
            }
            foreach (string part in name.Split('.'))
            {
                if (obj == null)
                {
                    return null;
                }
                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                {
                    return null;
                }
                obj = info.GetValue(obj, null);
            }
            return obj;
        }
