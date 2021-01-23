    private void ConvertWebChartChartToImage(WebChartControl chart, Stream stream)
    {
        // ...
        pcl.PrintingSystem.ExportToPdf(stream);
    }
    
    private void ConvertHTMLStringToPDF()
    {
        using (var stream = new MemoryStream())
        {
            // ...
            foreach (var item in listChartControl)
            {
                ConvertWebChartChartToImage(item, stream);
            }
            // ...
        }
    }
