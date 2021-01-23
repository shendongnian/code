    //if you do not have direct access to the worksheet object.
    SpreadsheetGear.IWorksheet worksheet1 = chart.Sheet.Workbook.Worksheets[chart.Sheet.Name];
    for (int i = 0; i < chart.SeriesCollection.Count; i++)
    {
      Color positiveColor = Color.FromArgb(79, 129, 189); // blue
      Color negativeColor = Color.FromArgb(192, 80, 77); // red
      chart.SeriesCollection[i].HasDataLabels = true;
      //Get the address of the series
      string address = chart.SeriesCollection[i].Values.ToString().Replace("=" + chart.Sheet.Name + "!", "");
      for (int j = 0; j < chart.SeriesCollection[i].Points.Count; j++)
      {
        double pointValue;
        //bool usePositiveValueColor = false;
        // If the point is -0.004 but the number format is "0.00",
        // label will be "0.00"
        //string label = chart.SeriesCollection[i].Points[j].DataLabel.Text;
        string label = (worksheet1.Cells[address][0, j].Value != null) 
          ? worksheet1.Cells[address][0, j].Value.ToString() : "0";
        chart.SeriesCollection[i].Points[j].Format.Fill.ForeColor.RGB =
            (System.Double.TryParse(label, out pointValue) && pointValue >= 0)
            ? positiveColor
            : negativeColor;
      }
    }
