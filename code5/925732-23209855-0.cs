    public static DataSet UpdateIncident(int incidentID, DateTime dateClosed,string description)
	{
		TechSupportDB techSupportDB = new TechSupportDB();
		var myConnection = techSupportDB.GetConnectionString();
		SqlCommand myCommand = new SqlCommand();
		myCommand.Parameters.AddWithValue("@IncidentID", incidentID);
		myCommand.Parameters.AddWithValue("@DateClosed", dateClosed);
		myCommand.Parameters.AddWithValue("@Description", description);
		myCommand.CommandText = 
		"update Incidents set DateClosed = @DateClosed, Description = @Description where IncidentID = @IncidentID";
		myCommand.Connection = myConnection;
		SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
		DataSet updatedIncidentsDataSet = new DataSet();
		myAdapter.UpdateCommand = myCommand;
		myAdapter.Update(updatedIncidentsDataSet);
		
		return updatedIncidentsDataSet;
	}
