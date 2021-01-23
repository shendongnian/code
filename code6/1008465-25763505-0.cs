    void LoadBarChart(string qurystring)
    {
        static readonly string conn =
            "Server=localhost;Port=3306;Database=ecvdb;Uid=root;Pwd=techsoft";
        Dictionary<String,int> callSummariesByTypeOfCall =
            new Dictionary<String,int>();
        MySqlConnection con = new MySqlConnection(conn);
        MySqlCommand comm = new MySqlCommand(qurystring, con);
        con.Open();
        MySqlDataReader dr = comm.ExecuteReader();
        // Get the data into a dictionary
        while (dr.Read())
        {
            String calltype = dr["TypeOfCall"].ToString();
            int summary = int.Parse(dr["SummaryOfCalls"].ToString(), CultureInfo.InvariantCulture);
            callSummariesByTypeOfCall[calltype] = summary;
        }
        // Do any other processing you need here
        // Bind the data onto the Series
        barChart.Series.DataBindXY(callSummariesByTypeOfCall.Keys, callSummariesByTypeOfCall.Values);
        barChart.Invalidate();
        pnlBar.Controls.Add(barChart);
    }
        
    
