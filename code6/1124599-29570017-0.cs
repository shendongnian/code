    private static string GetName<T>(T input)
    {
        var nameProperty =
            typeof (T)
                .GetProperties()
                .FirstOrDefault(propInfo =>
                    propInfo.Name.Equals("Name", StringComparison.OrdinalIgnoreCase));
        if (nameProperty == null)
        {
            throw new InvalidOperationException(
                "The input type does not have a name property");
        }
        return (string) nameProperty.GetValue(input);
    }
