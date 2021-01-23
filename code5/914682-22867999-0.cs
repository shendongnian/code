    string upstatus = "UPDATE memberlogin SET password=? where username = ?";
    OleDbConnection con = new OleDbConnection(connect);
    con.Open();
    OleDbCommand cmd2 = new OleDbCommand(upstatus, con);
    cmd2.Parameters.AddWithValue("@p1", newpwtxtbox.Text);
    cmd2.Parameters.AddWithValue("@p2", usernmaetxtbox.Text );
    cmd2.ExecuteNonQuery();
