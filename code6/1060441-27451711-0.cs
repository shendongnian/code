	using (var conn = new SqlConnection(myConnectionString))
	{
		conn.Open();
		using (var comm = conn.CreateCommand())
		{
			comm.CommandText = "select somedata from Foo";
			using (var rdr = comm.ExecuteReader())
			{
				using (var fs = File.Create(@"C:\temp\myfile.bin"))
				{
					const int BUFFER_SIZE = 2048;
					var buffer = new byte[BUFFER_SIZE];
					long offset = 0L;
					while (rdr.Read())
					{
						int count;
						while ((count = (int)rdr.GetBytes(0, offset, buffer, 0, BUFFER_SIZE)) > 0)
						{
							fs.Write(buffer, 0, count);
							offset += count;
						}
					}
				}
			}
		}
	}
