		private void SaveDetails(string scheduleID)
		{
			StringBuilder details = new StringBuilder();
			foreach(DataGridViewRow dgvr in this.YourDataGridView.Rows)
			{
				string name = dgvr.Cells[this.dgvColumn_Name.Name].Value.ToString();
				string key = dgvr.Cells[this.dgvColumn_Key.Name].Value.ToString();
				//Here you can check if values are ok(not empty or something else)
				//Create pair
				details.Append(Form1.DETAILSDELIMITER);
				details.Append(name);
				details.Append(Form1.NAMEKEYDELIMITER);
				details.Append(key);
			}
			//remove first space character
			if (details.Length > 0)
				details.Remove(0, 1);
			//Save data to database
			string query = "UPDATE ETAProcessSchedule SET ProcParameters=@Details WHERE EDIScheduleID=@ScheduleID";
			using (SqlConnection yourConnection = new SqlConnection(_YourConnectionString))
			{
				using (SqlCommand saveCommand = new SqlCommand(query, yourConnection))
				{
					//Adding parameters
					SqlParameter id = new SqlParameter { ParameterName = "@ScheduleID", SqlDbType = SqlDbType.NVarChar, Value = scheduleID };
					SqlParameter procParams = new SqlParameter { ParameterName = "@Details", SqlDbType = SqlDbType.NVarChar, Value = details.ToString() };
					saveCommand.Parameters.Add(id);
					saveCommand.Parameters.Add(procParams);
					saveCommand.ExecuteNonQuery();
					MessageBox.Show("Data Updated In Database Successfully");
				}
			}
		}
