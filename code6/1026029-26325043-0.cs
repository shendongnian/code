    using(OleDbConnection con = new OleDbConnection(conString))
    using(OleDbCommand computerStatus = con.CreateCommand())
    {
        computerStatus.CommandText = "update Computer SET Status= ? where PcNumber = ?";
        computerStatus.Parameters.AddWithValue("@status", "Occupied");
        computerStatus.Parameters.AddWithValue("@number", cboComputerNo.Text);
        computerStatus.ExecuteNonQuery();
    }
