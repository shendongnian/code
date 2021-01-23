    //this function creates the datatable from a specified class type, you may exclude properties such as primary keys
    public DataTable ClassToDataTable<T>(List<string> _excludeList = null)
    {
        Type classType = typeof(T);
        List<PropertyInfo> propertyList = classType.GetProperties().ToList();
        DataTable result = new DataTable(classType.Name);
        foreach (PropertyInfo prop in propertyList)
        {
            if (_excludeList != null)
            {
                bool toContinue = false;
                foreach (string excludeName in _excludeList)
                {
                    if (excludeName == prop.Name)
                    {
                        toContinue = true;
                        break;
                    }
                }
                if (toContinue)
                    continue;
            }
            result.Columns.Add(prop.Name, prop.PropertyType);
        }
        return result;
    }
    //add data to the table
    public void AddRow(ref DataTable table, object data)
    {
        Type classType = data.GetType();
        string className = classType.Name;
        if (!table.TableName.Equals(className))
        {
            throw new Exception("DataTableConverter.AddRow: " +
                                "TableName not equal to className.");
        }
        DataRow row = table.NewRow();
        List<PropertyInfo> propertyList = classType.GetProperties().ToList();
        foreach (PropertyInfo prop in propertyList)
        {            
            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName == prop.Name)
                {
                    if (table.Columns[prop.Name] == null)
                    {
                        throw new Exception("DataTableConverter.AddRow: " +
                                            "Column name does not exist: " + prop.Name);
                    }
                    row[prop.Name] = prop.GetValue(data, null);
                }
            }                        
        }
        table.Rows.Add(row);
    }
    //creates the insert string
    public string MakeInsertParamString(string _tableName, DataTable _dt, string _condition=null)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(string.Format("INSERT INTO [{0}] (", _tableName));
        for (int i = 0; i < _dt.Columns.Count; i++)
        {
            sb.Append(string.Format("{0}", _dt.Columns[i].ColumnName));
            if (i < _dt.Columns.Count - 1)
                sb.Append(", ");                
        }
        sb.Append(") VALUES (");
        for (int i = 0; i < _dt.Columns.Count; i++)
        {
            sb.Append(string.Format("@{0}", _dt.Columns[i].ColumnName));
            if (i < _dt.Columns.Count - 1)
                sb.Append(", ");
        }
        sb.Append(")");
        if (!string.IsNullOrEmpty(_condition))
            sb.Append(" WHERE " + _condition);
        return sb.ToString();
    }
    //inserts into the database
    public string InsertUsingDataRow(string _tableName, DataTable _dt, string _condition = null)
    {
        try
        {
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                string query = MakeInsertParamString(_tableName, _dt, _condition);
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                foreach (DataColumn col in _dt.Columns)
                {
                    var objectValue = _dt.Rows[0][col.ColumnName];                    
                    cmd.Parameters.AddWithValue("@" + col.ColumnName, objectValue);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();                
            }
            //return MakeInsertParamString(_tableName, _dt, _condition);
            return "Success";
        }
        catch (Exception ex) { return ex.Message; }
    }
