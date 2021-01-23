    public void AssignAndMapTypes<DatabaseType, TargetType>(DatabaseType db, ref TargetType target)
        {
            var dbType = db.GetType();
            var dbTypeProperties = dbType.GetProperties(System.Reflection.BindingFlags.Public);
            var targetType = target.GetType();
            var targetTypeProperties = targetType.GetProperties(System.Reflection.BindingFlags.Public);
            foreach (var prop in targetTypeProperties)
            {
                var matchingProp = dbTypeProperties.Where(e => { return (string.Compare(e.Name, prop.Name, true) == 0) && (e.PropertyType == prop.PropertyType) }).FirstOrDefault();
                if(matchingProp != null)
                {
                    prop.SetValue(target, matchingProp.GetValue(db, null), null);
                }
            }
        }
