		//Use SqlParameters in the query,
		//if not your application vulnerable for sql injection
		private void LoadScheduleDetails(string scheduleID)
		{
			//You working only with one column, do not use '*' in SELECT statement if not nessesary
			string query = "SELECT EDIScheduleID, ProcParameters FROM ETAProcessSchedule WHERE EDIScheduleID = @ScheduleID";
			DataTable details = new DataTable();
			//Get data from database
			using (SqlConnection yourConnection = new SqlConnection(_YourConnectionString))
			{
				using(SqlCommand detailsCommand = new SqlCommand(query, yourConnection))
				{
					//Adding parameter
					SqlParameter id = new SqlParameter { ParameterName = "@ScheduleID",  SqlDbType = SqlDbType.NVarChar,  Value = scheduleID };
					detailsCommand.Parameters.Add(id);
					using (SqlDataAdapter yourAdapter = new SqlDataAdapter(detailsCommand ))
					{
						yourAdapter.Fill(details);
					}
				}
			}
			this.YourDataGridView.Rows.Clear();
			if (details.Rows.Count > 0)
			{
				DataRow temp = details.Rows[0];
				//get column by name. 
				string[] pairs = temp.Field<String>("ProcParameters").Split(Form1.DETAILSDELIMITER);
				//Adding rows manually without DataSource
				foreach(string pair in pairs)
				{
					this.YourDataGridView.Rows.Add(pair.Split(Form1.NAMEKEYDELIMITER));
				}
			}
		}
