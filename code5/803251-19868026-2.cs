     public IList<EntityColumn> GetColumns()
        {
            var objectType = GetType();
            var properties = objectType.GetProperties();
            return properties.SelectMany(
                p => p.GetCustomAttributes<EntityAttribute>().SelectMany(a => a.GetColumns(this, p))).ToList();
        }
