        using (var conn = new SqlConnection(CONNECTION_STRING))
			{
				var command = new SqlCommand("YourStoredProcedure", conn);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@id", id);
				conn.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					using (var sw = new StreamWriter(string.Format(@"C:\temp\{0}.csv", reader.GetSchemaTable().TableName)))
					{
						var writer = new CsvWriter(sw);
						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{
								Console.WriteLine(reader.GetValue(i));
								writer.WriteField(reader.GetValue(i));
							}
							writer.NextRecord();
						}
					}
				}
			}
