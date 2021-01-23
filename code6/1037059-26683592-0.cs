		// initialize a connection string	
		string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
		
		// define the database query	
		string mySelectQuery="SELECT Name, Sales FROM REPS WHERE RegionID < 3;";
		// create a database connection object using the connection string	
		OleDbConnection myConnection = new OleDbConnection(myConnectionString);
		
		// create a database command on the connection using query	
		OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
		
		// open the connection	
		myCommand.Connection.Open();
		
		// create a database reader	
		OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		
		// since the reader implements and IEnumerable, pass the reader directly into
		// the DataBind method with the name of the Column selected in the query	
		Chart1.Series["Default"].Points.DataBindXY(myReader, "Name", myReader, "Sales");
