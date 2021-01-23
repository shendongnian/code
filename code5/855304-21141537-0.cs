	public class CitiesService
	{
		public DataSet DS;
		public OleDbConnection myConnection;
		public OleDbDataAdapter adapter;
		public OleDbDataAdapter adapter2;
		public CitiesService()
		{
		}
		public DataSet GetCities()
		{
			using (DataSet dataSet = new DataSet()) 
			{
				using (OleDbConnection myConnection = new OleDbConnection(ConnectionString))
				{			
					myConnection.Open();
					
					using (OleDbCommand myCmd = myConnection.CreateCommand())
					{
						myCmd.CommandType = CommandType.StoredProcedure;
						using (OleDbDataAdapter Adapter = new OleDbDataAdapter())
						{
							Adapter.SelectCommand = myCmd;
							try
							{
								Adapter.Fill(dataSet, "tblCities");
								dataSet.Tables["tblCities"].PrimaryKey = new DataColumn[] { dataSet.Tables["tblCities"].Columns["CityID"] };
							}
							catch (OleDbException ex)
							{
								throw ex;
							}
						}
					}
					myConnection.Close();
				}
				return dataSet;
			}
		}
	}
