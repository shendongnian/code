    public IEnumerable<bool> GetBools(YourClass obj)
    {
        return obj.GetType()
                  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .Where(x => x.PropertyType == typeof (bool))
                  .Select(x => (bool)x.GetValue(obj, null));
    }
