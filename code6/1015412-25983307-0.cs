    public static class Extensions
    {
        public static T GetPropertyValueOrDefault<T>(this Type t, object instnace, string Name, T defaultValue)
        {
            var prop = from p in t.GetProperties() where p.Name.Equals(Name) select p;
            if (prop.Any())
            {
                return (T) prop.First().GetValue(instnace);
            }
            return defaultValue;
        }
    }
