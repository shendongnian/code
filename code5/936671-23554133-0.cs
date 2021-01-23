    public static IEnumerable<T> GetEntity<T>(string storedProcedureName, params SqlParameter[] parameters)
	{
		try
		{
			using (SqlConnection connection =
				new SqlConnection("connectionString"))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(storedProcedureName, connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				if (parameters != null && parameters.Any())
				{
					command.Parameters.AddRange(parameters);
				}
				string result = (string)command.ExecuteScalar();
				return Deserialize<T>(result);
			}
		}
		catch (Exception ex)
		{
			// Handle the exception
			return (IEnumerable<T>)default(T);
		}
	}
	private static IEnumerable<T> Deserialize<T>(string xmlStream, params Type[] additionalTypes)
	{
		XmlSerializer serializer = additionalTypes == null ? new XmlSerializer(typeof(List<T>))
			: new XmlSerializer(typeof(List<T>), additionalTypes);
	   
		using (var reader = new XmlTextReader(new StringReader(xmlStream)))
		{
			if (!serializer.CanDeserialize(reader))
			{
				return (IEnumerable<T>)default(T);
			}
			return (IEnumerable<T>)serializer.Deserialize(reader);
		}
	}
