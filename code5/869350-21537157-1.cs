    string cmdText = "Insert INTO data(Name,Mail) Values(?,?)";
    using(OleDbConnection db_conn = new OleDbConnection(@"......."))
    using(OleDbCommand db_command = new OleDbCommand(cmdText, db_conn)) 
    {
        try
        {
            db_conn.Open();
            db_command.Parameters.AddWithValue("@p1",TextBox1.Text);
            db_command.Parameters.AddWithValue("@p2",TextBox2.Text);
            db_command.ExecuteNonQuery();
            Label5.Text = "Succesfully!";
        }
        catch(Exception ex)
        {
            // It is preferable to not catch the exception if you don't do anything, 
            // but if you catch then, at least, report what is wrong
            Response.Write("There is something wrong!" + ex.Message);
        }
     }
