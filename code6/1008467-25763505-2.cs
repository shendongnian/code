    void LoadBarChart(string qurystring)
    {
        static readonly string conn ="";
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
            int summary = int.Parse(dr["Calls"].ToString(), CultureInfo.InvariantCulture);
            callSummariesByTypeOfCall[type] = summary;
        }
        // Do any other processing you need here
        // Bind the data onto the Series
        barChart.Series.Points.DataBindXY(
            callSummariesByTypeOfCall.Keys,
            callSummariesByTypeOfCall.Values);
        barChart.Invalidate();
        pnlBar.Controls.Add(barChart);
    }
        
    
