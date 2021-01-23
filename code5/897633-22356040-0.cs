    private void chartTimer_Tick(object sender, EventArgs e)
    {
          if (seriesBps.Points.Count() > 300)
              seriesBps.Points.RemoveAt(0);
          seriesBps.Points.Add(wf.BitsPerSecond * 0.000001);
    
          DataPoint _point1 = default(DataPoint);
          foreach (DataPoint item in chart1.Series[0].Points)
          {
              item.Label = "";
              item.MarkerStyle = MarkerStyle.None;
          }
          chart1.Series[0].LegendText =  (wf.BitsPerSecond *     0.000001).ToString("#,##0");
          DataPoint Point1 = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1];
          Point1.Label = chart1.Series[0].Name;
                chart1.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
                chart1.Series[0].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                chart1.Series[0].SmartLabelStyle.MovingDirection = LabelAlignmentStyles.BottomRight;
                // --------------------------------------------------------------------------------------------------- //
          if (seriesPps.Points.Count() > 300)
              seriesPps.Points.RemoveAt(0);
          seriesPps.Points.Add(wf.PacketsPerSecond);
          DataPoint _point = default(DataPoint);
          foreach (DataPoint item in chart1.Series[2].Points)
          {
               item.Label = "";
               item.MarkerStyle = MarkerStyle.None;
           }
          chart1.Series[1].LegendText = wf.PacketsPerSecond.ToString("#,##0");
          DataPoint Point = chart1.Series[1].Points[chart1.Series[1].Points.Count - 1];
          Point.Label = chart1.Series[1].Name;
          chart1.Series[1].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
          chart1.Series[1].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
          chart1.Series[1].SmartLabelStyle.MovingDirection = LabelAlignmentStyles.BottomRight;
          chart1.ResetAutoValues();
    }
