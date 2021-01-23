    public static DataGridColumn CreateAppropriateColumn(string path, PropertyInfo info, string header, IRepository repository)
    {
        Func<string, PropertyInfo, string, IRepository, DataGridColumn>
            colfunc = null;
        // iterate over all the attributes, looking for one in our dictionary;
        // use Attribute.GetCustomAttributes because it doesn't ignore 'inherit'
        foreach (var attr in Attribute.GetCustomAttributes(info, true))
            if (map.TryGetValue(attr.GetType(), out colfunc))
                return colfunc(path, info, header, repository);
        if (info.PropertyType == typeof(bool) || info.PropertyType == typeof(bool?))
            return CreateDataGridCheckBoxColumn(path, info, header);
        return CreateTextBoxColumn(path, info, header);
    }
