    public ActionResult DownloadCsv()
		{
			using (var memStream = new MemoryStream())
			{
				using (var streamWriter = new StreamWriter(memStream))
				{
					var writer = new CsvWriter(streamWriter);
					using (var conn = new SqlConnection(CONNECTION_STRING))
					{
						var command = new SqlCommand("YourStoredProcedure", conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@id", id);
						conn.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								for (int i = 0; i < reader.FieldCount; i++)
								{
									Console.WriteLine(reader.GetValue(i));
									writer.WriteField(reader.GetValue(i));
								}
								writer.NextRecord();//you must also do this ALWAYS otherwise your .WriteFields wont be output for the current line
							}
						}
					}
					streamWriter.Flush();//note: you must flush
					return File(memStream.ToArray(), "text/csv", "My 1337 download name.csv");
				}
			}
		}
