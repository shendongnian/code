                 public ActionResult CreateChart()
                 {   
                 Bitmap image = new Bitmap(500, 50);
                 Graphics g = Graphics.FromImage(image);
                 var chart1 = new System.Web.UI.DataVisualization.Charting.Chart();
                 chart1.Width = 1000;
                 chart1.Height = 300;
                 chart1.ChartAreas.Add("xAxis").BackColor = System.Drawing.Color.FromArgb     (64,System.Drawing.Color.White);
                 chart1.Series.Add("xAxis");
                 chart1.Series["xAxis"].Points.AddY(8);
                 chart1.Series["xAxis"].Points.AddY(8);
                 chart1.Series["xAxis"].Points.AddY(8);
                 chart1.Series["xAxis"].Points.AddY(6);
                 chart1.Series["xAxis"].Points.AddY(5);    
                 chart1.Series["xAxis"].IsValueShownAsLabel = true;
                 chart1.BackColor = Color.Transparent;
                 MemoryStream imageStream = new MemoryStream();
                 chart1.SaveImage(imageStream, ChartImageFormat.Png);
                 chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.SystemDefault;
                 Response.ContentType = "image/png";
                 imageStream.WriteTo(Response.OutputStream);
                 g.Dispose();
                 image.Dispose();
                 return null;
            }
