    public static class OrmLiteBinaryCreateExtensions
    {
    	/// <summary>
    	/// WARNING: this will drop all of the existing varbinary columns!
    	/// </summary>
    	public static void UpdateByteToBinary<T>(this IDbConnection dbConn)
    	{
    		var modelDef = ModelDefinition<T>.Definition;
    		var tableName = OrmLiteConfig.DialectProvider.GetQuotedTableName(modelDef);
    		var definitions = modelDef.FieldDefinitions.Where<FieldDefinition>(f => f.FieldType == typeof(byte[]));
    
    		foreach (var def in definitions)
    		{
    			var columnName = OrmLiteConfig.DialectProvider.GetQuotedColumnName(def.FieldName);
    			dbConn.ExecuteNonQuery(string.Format("ALTER TABLE {0} DROP COLUMN {1}", tableName, columnName));
    			dbConn.ExecuteNonQuery(string.Format("ALTER TABLE {0} ADD {1} [varbinary](max) filestream NULL", tableName, columnName));
    		}
    	}
    }
