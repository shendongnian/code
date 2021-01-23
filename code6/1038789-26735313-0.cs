    Points pts = (Microsoft.Office.Interop.Excel.Points)series.Points(Type.Missing);
     foreach (Point pt in pts) { if(yourcondition) {
        pt.Border.Color = (int)XlRgbColor.rgbDarkOrange;
        pt.MarkerBackgroundColor = (int)XlRgbColor.rgbDarkOrange;
        pt.MarkerForegroundColor = (int)XlRgbColor.rgbDarkOrange;
      }
     }
