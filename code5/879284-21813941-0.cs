    using (SqlConnection con = new SqlConnection(clsConnection.getConnectionString()))
    using (SqlCommand command = new SqlCommand("insert into HMS.dbo.CheckInOut(Room_No,Name,DateTime,CheckInOut) Values(02,'Name',GETDATE(),'CheckIn')", con))
    {
        con.Open();
        command.ExecuteNonQuery();
        lblmissing.Text = "Recorded Inserted Successfully"; 
    }
