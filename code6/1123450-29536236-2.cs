    public IEnumerable<TCustomEntity> SqlQuery<TCustomEntity>(string query,
        IDictionary<string, object> parameters, // suggestion: default to null
        CommandType commandType // suggestion: default to CommandType.Text
    ) where TCustomEntity : class
    {
        var sqlConnection = _context.Database.Connection;
        if (parameters != null) {
            foreach (object val in parameters.Values) {
                if (val is DataTable) {
                    var dt = (DataTable)val;
                    // suggestion: might want to only do if dt.GetTypeName() is null/""
                    dt.SetTypeName(dt.TableName);
                }
            }
        }
        return sqlConnection.Query<TCustomEntity>(query, parameters,
            commandType: commandType);
    }
