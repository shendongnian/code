    public static Tuple<string,string>[] GetFieldNames<T>(IEnumerable<T> items) where T : class
    {
        var result =
            typeof (T).GetProperties()
                .Where(p => SystemTypes.Contains(p.PropertyType) &&p.GetCustomAttribute<DescriptionAttribute>() != null)
                .Select(
                    p =>
                        new Tuple<string, string>(p.Name,
                            p.GetCustomAttribute<DescriptionAttribute>().Description));
        return result.ToArray();
    }
