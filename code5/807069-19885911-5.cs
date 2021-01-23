    public JsonProperty GetClosestMatchProperty(string propertyName)
    {
        propertyName = Regex.Replace(propertyName, "[^A-Za-z0-9]+", "");
        JsonProperty property = GetProperty(propertyName, StringComparison.Ordinal);
        if (property == null)
            property = GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);
        return property;
    }
