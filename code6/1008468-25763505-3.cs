    void LoadBarChart(string qurystring)
    {
        String conn = Strings.ConnectionString; // You fill this in.
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
            callSummariesByTypeOfCall[calltype] = summary;
        }
        // Do any other processing you need here
        // Bind the data onto the Series
        Series series = new Series
        {
            Name = "series2",
            IsVisibleInLegend = false,
            ChartType = SeriesChartType.Column
        };
        series.Points.DataBindXY(
            callSummariesByTypeOfCall.Keys,
            callSummariesByTypeOfCall.Values);
        barChart.Series.Add(series);
        barChart.Invalidate();
        pnlBar.Controls.Add(barChart);
    }
        
    
