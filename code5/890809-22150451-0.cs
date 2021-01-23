    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
        using (SqlCommand todc1 = new SqlCommand("Select * from DCR Where Comp_Date >= @todayDate And Comp_Date < @nextDay Order By Comp_Date Desc", conn))
        {
            todc1.Parameters.AddWithValue("@todayDate", DateTime.Today);
            todc1.Parameters.AddWithValue("@nextDay", DateTime.Today.AddDays(1));
            DataTable dt = new DataTable();
            dt.Load(todc1.ExecuteReader());
            //bind to report viewer. 
            //yourReportViewer.DataSource = dt;
        }
    }
