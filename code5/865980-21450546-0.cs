		string connectionString = string.Format(Thread.CurrentThread.CurrentCulture, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;'", excelFilePath);
		DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
		using (DbConnection connection = factory.CreateConnection())
		{
			connection.ConnectionString = connectionString;
			using (DbCommand command = connection.CreateCommand())
			{
				command.CommandText = @"SELECT [File], [ItemName], [ItemDescription], [Photographer name], [Date], [Environment site] FROM [Metadata$]";
				connection.Open();
				using (DbDataReader dr = command.ExecuteReader())
				{
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							.......
						}
					}
				}
				connection.Close();
			}
		}
