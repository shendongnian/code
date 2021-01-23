    try
    {
        //Check if chart has at least one enabled series with points
        if (chart1.Series.Any(s => s.Enabled && s.Points.Count>0))
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image Files|*.png;";
            save.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff";
            save.Title = "Save Chart Image As file";
            save.DefaultExt = ".png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                var imgFormats = new Dictionary<string, ChartImageFormat>()
                {
                    {".bmp", ChartImageFormat.Bmp}, 
                    {".gif", ChartImageFormat.Gif}, 
                    {".jpg", ChartImageFormat.Jpeg}, 
                    {".jpeg", ChartImageFormat.Jpeg}, 
                    {".png", ChartImageFormat.Png}, 
                    {".tiff", ChartImageFormat.Tiff}, 
                };
                var fileExt = System.IO.Path.GetExtension(save.FileName).ToString().ToLower();
                if (imgFormats.ContainsKey(fileExt))
                {
                    chart1.SaveImage(save.FileName, imgFormats[fileExt]);
                }
                else
                { 
                    throw new Exception(String.Format("Only image formats '{0}' supported", string.Join(", ", imgFormats.Keys)));
                }
            }
        }
        else
        {
            throw new Exception("Nothing to export");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("SaveChartAsImage()", ex.Message);
    }
