    String statement = "INSERT INTO MyTable(SubmitDate, FirstName, LastName, Email, Phone, Major, Description, HearAbout)";                    
    statement += "VALUES (";
    statement += "'" + DateTime.Now.ToShortDateString() + "',";
    statement += "'" + txtFname.Text + "', ";  
    conn = new OdbcConnection(connectionString);
    command = new OdbcCommand(statement, conn);
