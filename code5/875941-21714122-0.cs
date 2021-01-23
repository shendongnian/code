    //this is executed first
    private void ImportData(IDataMapping tableMap)
    {
        //destType is a class of POCOs that match column names from a database table
        //the class inherits from a base class called SchemaObject which inherits from ISchemaObject which itself inherits from INotifyPropertyChanged
        //an example name would be 'SchemaEmployees' where employees is the destination table name
        Type destType = typeof(ISchemaObject).Assembly.GetTypes()
                        .FirstOrDefault(t => t.Name.ToLower() == "schema" + tableMap.tableName.ToLower());
        if (destType == null)
            throw new NullReferenceException("Could not find class mapping for table " + tableMap.tableName + ".");
        //the list of public properties on the POCO class, i.e. the columns from the database table
        List<PropertyInfo> destProps = destType.GetProperties().ToList();
        //here I create a DataSet from a DataAdapter for the destination insert table 
        //here I get a DbDataReader from a source database and run ExecuteReader()
        using (DataSet ds = GetTableDs())
        using (DbDataReader reader = GetSourceData())
            while (reader.Read())
            {
                TableInsert(tableMap, reader, ds, destType, destProps);
            }
    }  
    //this is where the DataRow for the destination database is created and the columns mapped to the class POCOs
    private void TableInsert(
        IDataMapping tableMap,
        DbDataReader r, //source
        DataSet ds, //destination
        Type destClassType,
        IList<PropertyInfo> destClassProperties)
    {
        var dr = ds.Tables[0].NewRow();
        var dest = dr.CreateItemFromRow(destClassType, destClassProperties) as ISchemaObject;
        //sets the DataRow column value when the class property value changes
        dest.PropertyChanged += (sender, eArgs) =>
        {
            dr[eArgs.PropertyName] =
                destClassType
                .GetType()
                .GetProperty(eArgs.PropertyName, BindingFlags.Public | BindingFlags.Instance)
                .GetValue(sender, null);
        };
        //the source DataReader row is converted to a Dynamic class
        //it's not type safe, but the source changes frequently so properly mapping it would add undue complexity to the project        
        var srcEnt = new DynamicEntityGenerator.DataReaderEntity(r);
        dynamic dynSrc = srcEnt;
        //in this method the destination class (bound to the DataRow that will be inserted) properties are mapped to the source Dynamic class's properties
        tableMap.MapInsertClasses<ISchemaObject>(dynSrc, dest);
        ds.Tables[0].Rows.Add(dr);
    }  
  
    //DataRow extension method for mapping the row to a class containing properties with the same name as the DataColumn names
    public static ISchemaObject CreateItemFromRow(
        this DataRow row,
        Type type,
        IList<PropertyInfo> properties)
    {
        var item = (ISchemaObject)Activator.CreateInstance(type);
        foreach (var property in properties)
        {
            if (row[property.Name] != DBNull.Value)
                property.SetValue(item, row[property.Name], null);
        }
        return item;
    }  
