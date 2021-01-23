    public void AddRoutes(List<string> values, string propertyName, RouteValueDictionary dictionary)
    {
        for (int i = 0; i < values.Count; i++ )
        {
            string key = string.Format("{0}[{1}]", propertyName, i);
            dictionary[key] = values[i];
        }
    }
