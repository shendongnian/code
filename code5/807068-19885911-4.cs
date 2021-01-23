    public JsonProperty GetClosestMatchProperty(string propertyName)
    {
        JsonProperty property = GetProperty(propertyName, StringComparison.Ordinal);
        if (property == null)
            property = GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);
        return property;
    }
