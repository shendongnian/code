    string query =  "INSERT INTO MyTable(SubmitDate, FirstName, LastName, Email, Phone, Major, Description, HearAbout)";                    
    query += " VALUES (@SubmitDate, @FirstName, @LastName, @EMail, @Phone, @Major, @Description, @HearAbout)";
    conn = new OdbcConnection(connectionString);
    command = new OdbcCommand(query, conn);
    command.Parameters.AddWithValue("@SubmitDate", DateTime.Now.ToShortDateString());
    command.Parameters.AddWithValue("@FirstName",  txtFname.Tex);
    ...
    conn.Open();
    command.ExecuteNonQuery();
 
