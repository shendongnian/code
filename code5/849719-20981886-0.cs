    var props = obj.GetType()
               .GetProperties(BindingFlags.Instance | BindingFlags.Public)
               .Select(p => new
               {
                   Property = p,
                   Attribute = p.GetCustomAttribute<ScaffoldColumnAttribute>()
               })
               .Where(p => p.Attribute != null && p.Attribute.Scaffold == false)
               .ToList();
