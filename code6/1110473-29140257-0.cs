    void AddSerie(string stockName)
    {
        try
        {
            Legend legend = new Legend(stockName);
            Chart1.Legends.Add(legend);
            Series series = new Series(stockName);
            Chart1.Series.Add(series);
             string[] _data = new string[3];
            _data[0] = stockName;
            _data[1] = "2010-01-01";
            _data[2] = "2015-03-15";
            DataSet ds = DBSelect(_data, "web_price_series");
            Chart1.DataSource = ds;
            Chart1.Series[stockName].XValueMember = "tdate";
            Chart1.Series[stockName].YValueMembers = "value";
            Chart1.Series[stockName].ChartType = SeriesChartType.Line;
             
            foreach (DataRow row in ds.Tables[0].Rows)
            {
               Chart1.Series[stockName].Points.AddXY(row[0], row[1]);
            }
           // Chart1.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
