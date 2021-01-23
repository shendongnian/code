     foreach (PropertyInfo prop in objType.GetProperties())
            {
                var val = prop.GetValue(x,null);
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType.IsGenericType)   // Is there a better way?
                {
                    dynamic dd = val;
                    foreach (object lval in dd)  
                    {
                        strList.Add(lval.ToString());
                    }
                }
