    DataTable tblData = new DataTable();
    string sql = @"SELECT ed.EmpCode,ed.Name,ed.Age,ed.Date 
                   FROM MusterRoll mr
                   INNER JOIN EmpDetails ed 
                      ON mr.Date = ed.Date
                   WHERE mr.EmpCode=@EmpCode AND mr.Month=1 AND mr.Year=2015";
    using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
    using(var sda = new SqlDataAdapter(sql, conn))
    {
        var codeParam = new SqlParameter("@EmpCode", SqlDbType.VarChar).Value = code; // change type accordingly
        sda.SelectCommand.Parameters.Add(codeParam);
        sda.Fill(tblData); // no need for conn.Open/Close with SqlDataAdapter.Fill
    }
    gvSingleemp.Visible = true;
    gvSingleemp.DataSource = tblData;
