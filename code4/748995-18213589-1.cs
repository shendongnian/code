        var filtered = properties.Where(p => 
            {
                if(!p.PropertyType is MyMetaData)
                {
                    return false;
                }
                var item = (MyType) p.GetValue(obj);
                return item.Name == "name"
                    && item.Length == 10
            }
        ).ToList();
