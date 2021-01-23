    private string BuildCommandText(string columnName, string lookUpTableName, 
        string lookUpPropertyName)    
    {
        StringBuilder builder = new StringBuilder();
    
        builder.Append("SELECT ");
        builder.Append(columnName);
        builder.Append(" FROM ");
        builder.Append(lookUpTableName);
        builder.Append(" WHERE ");
        builder.Append(lookUpPropertyName);
        builder.Append(" = @FKID");
        //The result query will look something like:
        //SELECT ColumnName FROM TableName WHERE PropertyName = @FKID
    
        return builder.ToString();
    }
