    public static DataGridColumn CreateAppropreateColumn(string path, PropertyInfo info, string header, IRepository repository)
    {
        //Dictionary of methods to call. Add in all your different column types here with their respective creation functions
        var columnCreationStrategy = new Dictionary<Type, Func<DataGridColumn>>()
            {
                {typeof(DbComboBoxAttribute), () => CreateComboBoxColumn(path,info,header)},
                {typeof(DescribedByteEnumComboBoxAttribute), () => CreateEnumComboBoxColumn(path,info,header, repository)}
            };
    
        //Just get all attributes here, then return the first successful match
        var attributeList = info.GetCustomAttributes(true).ToList();
        foreach (var attribute in attributeList)
        {
            var type = attribute.GetType();
            if (columnCreationStrategy.ContainsKey(type))
                return columnCreationStrategy[type].Invoke();
        }
        //Maybe throw some exception here? Depends on how you want to handle it. You could even have a default column generation method here
        return null;
    }
