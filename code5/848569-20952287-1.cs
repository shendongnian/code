    List<ReportData> myReportData = new List<ReportData>();
    using(SqlConnection con = new SqlConnection(...))
    using(SqlCommand cmd = new SqlCommand("SELECT * from tblManagerReports", con))
    {
       con.Open();
       using(SqlDataReader reader = cmd.ExecuteReader())
       {
            while(reader.Read())
            {
                ReportData rpt = new ReportData();
                rpt.ReportID = Convert.ToInt32(reader[0]);
                rpt.ReportName = reader[1].ToString();
                rpt.SProc = reader[2].ToString();
                rpt.SQLView = reader[3].ToString();
                myReportData.Add(rpt);
            }
       }
    }
