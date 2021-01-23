	public static class StoredProcExtensions
	{
		public static List<T> ExecStoredProcedure<T>(this IDbConnection connection, string procedureName, object parameters = null, string outputCursor = "cursorParam")
		{
			return connection.Exec(c => {
				c.CommandText = procedureName;
				c.CommandType = CommandType.StoredProcedure;
				// Create the parameters from the parameters object
				if(parameters != null)
					foreach(var property in parameters.GetType().GetPublicProperties())
						c.Parameters.Add(new OracleParameter(property.Name, property.GetValue(parameters)));
				// Add the output cursor
				if(outputCursor != null)
					c.Parameters.Add(new OracleParameter(outputCursor, OracleDbType.RefCursor) { Direction = ParameterDirection.Output });
				// Return the result list
				return c.ExecuteReader().ConvertToList<T>();
			});
		}
	}
