      ChartArea ca = chart1.ChartAreas[0];
      TextAnnotation ta = new TextAnnotation();
      DataPoint dp0 = Series2.Points[0];  // pick a datapoint!
      ta.Text = dp0.YValues[0] + "";
      ta.ForeColor = dp0.Color;
      ta.AxisY = ca.AxisY;
      ta.Y = dp0.YValues[0];
      ta.X = 5;  // pick a value that fits with your y-axis!
      ta.Alignment = ContentAlignment.MiddleLeft;
      chart1.Annotations.Add(ta);
