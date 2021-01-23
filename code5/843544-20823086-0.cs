    private static string[] GetNaviProps(Type entityType)//eg typeof(Employee)
    {
        return entityType.GetProperties()
                         .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) ||  p.PropertyType.Namespace == entityType.Namespace)
                         .Select(p => p.Name)
                         .ToArray();
    }
