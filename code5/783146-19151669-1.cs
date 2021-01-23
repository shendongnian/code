    public static void LogValues(string text, object values)
    {
        var properties = values.GetType().GetProperties();
        Log.WriteLine(text + ": " + string.Join(", ",
            properties.Select(property =>
            {
                var name = property.Name;
                var value = property.GetValue(values);
                return name + " = " + (value != null ? value.ToString() : "null");
            })));
    }
