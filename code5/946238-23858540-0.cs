	public static IEnumerable<TasCriteria> GetCriterias(
                                string storedProcedureName,
                                Func<IEnumerable<TasCriteria>> enumerateMethod)
	{
		using (var conn = new SqlConnection(_connectionString))
		{
			var com = new SqlCommand();
			com.Connection = conn;
			com.CommandType = CommandType.StoredProcedure;
			com.CommandText = storedProcedureName;
			var adapt = new SqlDataAdapter();
			adapt.SelectCommand = com;
			var dataset = new DataSet();
			adapt.Fill(dataset);
			return enumerateMethod(dataset.Tables[0]);
		}
	}
