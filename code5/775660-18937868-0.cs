	IAsyncEnumerable<Employee> async = AsyncEnumerableEx.Create(
                                                      async (y, cancellationToken) =>
	{
		using (var connection = new SqlConnection(ConfigurationManager
                                .ConnectionStrings["DBConnString"].ConnectionString))
		{
			await connection.OpenAsync(cancellationToken);
			using (var command = new SqlCommand(@"SELECT * FROM EMPLOYEES",
                                                connection))
			{
				using (var reader = await
                                       command.ExecuteReaderAsync(cancellationToken))
				{
					while (await reader.ReadAsync(cancellationToken))
					{
						await y.YieldReturn(new Employee()
						{
							Id = ReadField<int>(reader, "Id"),
							Name = ReadField<string>(reader, "Name")
						});
					}
				}
			}
		}
	});
