    public ActionResult Chart()
    {
        var chart = new System.Web.UI.DataVisualization.Charting.Chart();
        chart.ChartAreas.Add(new ChartArea());
        // Dummy data
        var data = Enumerable.Range(1, 2).Select(i => new { Name = i.ToString(), Count = i }).ToArray();
        chart.Series.Add(new Series("Data"));
        chart.Series["Data"].ChartType = SeriesChartType.Column;
        for (int x = 0; x < data.Length; x++)
        {
            // Add each point and set its Label
            int ptIdx = chart.Series["Data"].Points.AddXY(
                 data[x].Name,
                 data[x].Count);
            DataPoint pt = chart.Series["Data"].Points[ptIdx];
            pt.Label = "#VALX: #VALY";
            pt.Font = new System.Drawing.Font("Arial", 12f, FontStyle.Bold);
            pt.LabelForeColor = Color.Green;
        }
        using (MemoryStream ms = new MemoryStream())
        {
            chart.SaveImage(ms, ChartImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }
    }
