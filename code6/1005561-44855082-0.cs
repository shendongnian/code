    public void PopulateFields(string jsonData)
    {
        var jsonGraph = JObject.Parse(jsonData);
        foreach (var prop in this.GetType().GetProperties())
        {
            try
            {
                prop.SetValue(this, fields[prop.Name].ToObject(prop.PropertyType), null);
            }
            catch (Exception e)
            {
                // deal with the fact that the given
                // json does not contain that property
            }
    }
