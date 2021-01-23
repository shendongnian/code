    string str = "UPDATE Categories SET HRS_LEVEL_AMOUNT = @value1 WHERE ID=@value2";
    using (OleDbConnection con = new OleDbConnection(strConnstring))
    {
        using (OleDbCommand cmd = new OleDbCommand(str, con))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@value1", tempVal);
            cmd.Parameters.AddWithValue("@value2", caseage);
            con.Open();
            cmd.ExecuteNonQuery();
            con.close();
        }
    }
