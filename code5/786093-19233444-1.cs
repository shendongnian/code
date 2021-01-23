    public int SubmitData(string pid, string ptitle, string date, string pqr, string pd, string ps, string pr, string pme, string pef, string pet, string psno, string pqs, string pds, string pmd, string pmr, string pmn)
    {
        string sql = 
           "BEGIN TRANSACTION; " +
           
           "DECLARE @result int;"
           "INSERT INTO PC_QA_REPORT_1 (" +
             " Project_ID, Project_Title, Date, Project_Quality_Rating, Project_Decision, " +
             " Project_Strategic, Project_Relevant, Project_Monitoring_Eval, " + 
             " Project_Efficient, Project_Effective, Project_Sus_Nat_Own, " +
             " Project_QA_Summary, Project_Document_Status" +
          ") VALUES (" +
             "@pid, @ptitle, @date, @pqr, @pd, @ps, @pr, @pme, @pef, @pet, @psno, @pqs, @pds" + 
          ");" +
          " SET @result = @@rowcount; " +
          "INSERT INTO PC_QA_REPORT_2 (" + 
             " Project_M_Date, Project_M_Responsibility,Project_M_Notes" +
          ") VALUES(" + 
            " @pmd, @pmr, @pmn" +
          ");" + 
          " SELECT @result + @@rowcount; " +
          " COMMIT; ";
        //best to use a new connection object for each call to the database
        using (var con = new SqlConnection(" <connection string here> "))
        using (var cmd = new  SqlCommand(sql, con))
        {
            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(pid);
            cmd.Parameters.Add("@ptitle", SqlDbType.NVarChar, 100).Value = ptitle;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Parse(date);
            cmd.Parameters.Add("@pqr", SqlDbType.Float).Value = double.Parse(pqr);
            cmd.Parameters.Add("@pd", SqlDbType.NVarChar, 5).Value = pd;
            //You can fill in the rest of the parameters on your own
            con.Open();
            return (int)cmd.ExecuteScalar();
         }
    }
