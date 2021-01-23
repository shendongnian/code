	using System;
	using System.Collections.Generic;
	using Oracle.DataAccess.Client;
	namespace Utils
	{
		class Test
		{
			private class Class
			{
				public string FirstProperty { get; set; }
				public string SecondProperty { get; set; }
			}
			private void ReadData(string connString, string cmdString)
			{
				List<Class> data = new List<Class>();
				using (OracleConnection conn = new OracleConnection() { ConnectionString = connString })
				using (OracleCommand objCmd = new OracleCommand()
				{
					Connection = conn,
					CommandText = cmdString
				})
				{
					try
					{
						conn.Open();
					}
					catch (OracleException)
					{
						OracleConnection.ClearPool(conn);
						conn.Open();
					}
					using (OracleDataReader dataReader = objCmd.ExecuteReader())
					{
						while (dataReader.Read())
							data.Add(new Class()
							{
								FirstProperty = dataReader.GetString(0),
								SecondProperty = dataReader.GetString(1)
							});
					}
					conn.Close();
				}
				//some long operation using data
			}
		}
	}
