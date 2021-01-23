    public ActionResult ChartImage()
    {
        var chart = new System.Web.UI.DataVisualization.Charting.Chart();
        .....//setup properties and data
        using (var ms = new MemoryStream())
        {
             chart.SaveImage(ms, ChartImageFormat.Png);
             ms.Seek(0, SeekOrigin.Begin);
             return File(ms.ToArray(), "image/png", "mychart.png");
        }
    }
