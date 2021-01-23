        try
        {
            Command = dbConnection.CreateCommand();
            Command.CommandText = Query;
            using (Reader = Command.ExecuteReader()) // 'using' forces a call to `Dispose`/`Close` at the end of the block
            {
				if (Reader.HasRows)
				{
					ArrayList columnBuilder = new ArrayList();
					while (Reader.Read())
					{
						try { columnBuilder.Add(Reader.GetInt32(0)); }
						catch { columnBuilder.Add(0); }
					}
					return (int[])columnBuilder.ToArray(typeof(int));
				}
				else
				{
					return new int[0];
				}
            }
        }
