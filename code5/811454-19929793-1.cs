		private void GetSchema(string connectionString, string query, out string data, out string schema)
		{
			using (var conn = new Npgsql.NpgsqlConnection(connectionString))
			using (var da = new Npgsql.NpgsqlDataAdapter(query, conn))
			using (var ds = new DataSet())
			using (var dataStream = new MemoryStream())
			using (var schemaStream = new MemoryStream())
			{
				conn.Open();
				da.Fill(ds);
				ds.WriteXml(dataStream);
				ds.WriteXmlSchema(schemaStream);
				dataStream.Position = 0;
				schemaStream.Position = 0;
				using (var dataReader = new StreamReader(dataStream))
				using (var schemaReader = new StreamReader(schemaStream))
				{
					data = dataReader.ReadToEnd();
					schema = schemaReader.ReadToEnd();
				}
			}
		}
