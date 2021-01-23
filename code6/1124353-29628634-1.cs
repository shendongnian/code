    string temp = query.ToLower();
    
    // Building my "dummy" query
    if ((temp.StartsWith("select *")) && (!temp.Contains("where")) && (!temp.Contains("order")))
        temp += " where false";
    _dAdapter = new NpgsqlDataAdapter(temp, this.DatabaseConnection);
    NpgsqlCommandBuilder cBuilder = new NpgsqlCommandBuilder(_dAdapter);
    _dAdapter.DeleteCommand = cBuilder.GetDeleteCommand();
    _dAdapter.InsertCommand = cBuilder.GetInsertCommand();
    _dAdapter.UpdateCommand = cBuilder.GetUpdateCommand();
    _dAdapter.FillSchema(_dataTable, SchemaType.Mapped);
    
    _dAdapter.SelectCommand.CommandText = query; // NOTE THIS!
    
    _dAdapter.Fill(_dataTable);
