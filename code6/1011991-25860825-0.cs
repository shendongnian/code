    using (OleDbConnection conn = new OleDbConnection(YourConnectionStringHere))
    using (OleDbCommand cmd = new OleDbCommand(SQLString, conn))
    {
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("p1").Value = QuestionID;
        cmd.Parameters.Add("p2").Value = CallMonitorNumber;
        cmd.Parameters.Add("p3").Value = When;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
