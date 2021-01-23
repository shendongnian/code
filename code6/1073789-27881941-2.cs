    public static string GenerateInsertQuery(IModel model)
    {
        Type myType = model.GetType();
        string query = "INSERT INTO [" + myType.Name + "] ( ";
        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        string[] nonDBFields = { "isValid", "isChanged", "CREATEDON", "CHANGEDON", "CHANGEDBY" };
        foreach (PropertyInfo prop in props)
        {
            if (prop.Name == nonDBFields[0] || prop.Name == nonDBFields[1] || prop.Name == nonDBFields[3] || prop.Name == nonDBFields[4])
            {
                continue;
            }
            else
                query += "[" + prop.Name + "] , ";
        }
        query.Remove(query.LastIndexOf(","), 1);
        query += " ) VALUES (";
        foreach (PropertyInfo prop in props)
        {
            if (prop.Name == nonDBFields[0] || prop.Name == nonDBFields[1] || prop.Name == nonDBFields[3] || prop.Name == nonDBFields[4])
            {
                continue;
            }
            else
            {
                if (prop.Name == nonDBFields[2])
                {
                    query += "GETDATE(),";
                    continue;
                }
                else
                {
                    query += " @" + prop.Name + ", ";
                    continue;
                }
            }
        }
        query.Remove(query.LastIndexOf(','), 1);
        query += " )";
        return query;
    }
