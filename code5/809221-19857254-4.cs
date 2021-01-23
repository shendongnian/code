    SqlConnection con = new SqlConnection("...");
    string strSQL = "SELECT SUM(case when Status = 'P' then WeightagePercent else 0 end) as passed, " + 
                    "       SUM(case when Status = 'F' then WeightagePercent else 0 end) as failed " + 
                    "FROM ProoferTbl2 " + 
                    "GROUP BY Status";
    SqlCommand cmd = new SqlCommand(strSQL, con);
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();   
    int passed = 0, failed = 0; 
    while (reader.Read())
    {
        passed = (int) reader["passed"];
        failed = (int) reader["failed"];
    }
    reader.Close();
    con.Close();
    If(passed > failed)
    { 
        Messagebox.show("Pass")
    }
