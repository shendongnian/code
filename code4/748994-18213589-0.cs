        var filtered = properties.Where(p => 
            {
                var item = (MyType) p.GetValue(obj);
                return p.PropertyType == typeof(MyMetaData)
                    && item.Name == "name"
                    && item.Length == 10
            }
        ).ToList();
