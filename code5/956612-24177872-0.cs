            var tblNoteProperties = contextEntities
                .GetType()
                .GetProperties()
                .Where(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.PropertyType.GetGenericArguments()[0])
                .Where(t => t.Name == "tblNote")
                .SelectMany(t => t.GetProperties())
                .ToArray();
