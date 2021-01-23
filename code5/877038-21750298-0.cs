	class OleDB   
	{
		public string [] readexcel()
		{
			string[] test = new string[23];
			//Below runs the OleDB connections which essentially turns excel into an Access database.
			string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/nlongmore/Documents/Ebay Click and Collect/Ebay MIP/MIP - UK - General Metadata.xlsx;Extended Properties=\"Excel 12.0;HDR=YES;\"";
			//Parameters for OleDB  
			using (OleDbConnection connection = new OleDbConnection(conn))
			{   //Opens the connection
				connection.Open();
				OleDbCommand command = new OleDbCommand("select Value from [Domestic Shipping Service$]", connection); //Searches the column Value from the Worksheet DSS
				using (OleDbDataReader dr = command.ExecuteReader())
				{ //Reads in the data
					for (int x = 0; x < 23; x++)
					{
						while (dr.Read())
						{
						   var details = Convert.ToString(dr[0]);
						   test[x] = details;   
						}
					}
					connection.Close();       
				}
			}
			return test;
		}
	}
