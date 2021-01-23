            SqlCommand Command = new SqlCommand(YourQuery,myConnection);
          
			myConnection.Open();
			int Rows=0;
			try
			{
				Rows = Command.ExecuteNonQuery();
				myConnection.Close();
				
			}
			catch (Exception ex)
			{
				conSMS.Close();
				string Msg = ex.Message;
                                //I log my exceptions
				//Log("ERROR: "+RemoveSQ(Query));
				//Log(RemoveSQ(Msg));
			}
			//check Rows here if there is no exception
