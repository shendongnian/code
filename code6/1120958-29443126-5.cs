    foreach (var costYear in result)
    {
        var properties = costYear.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var value = property.GetValue(costYear, null);
        }
    }
