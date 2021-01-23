    // just a few test data in Series S1 & S2..
    S1.Points.AddXY(1, 13, 14.5);  // the dummy point
    S1.Points.AddXY(1, 15,22);
    S2.Points.AddXY(1, 7,8.5); // 2nd dummy
    S2.Points.AddXY(1, 9,13);
    // set the labels
    foreach (Series S in chart1.Series)
        for (int i = 0; i < S.Points.Count; i+=2 )
        {
            DataPoint pt0 = S.Points[i];
            DataPoint pt1 = S.Points[i + 1];
            pt0.Color = Color.Transparent;
            pt0.SetCustomProperty("BarLabelStyle", "Right");
            pt0.Label = pt1.YValues[0] + " ";
            pt1.SetCustomProperty("BarLabelStyle", "Outside");
            pt1.Label = " " + pt1.YValues[1];
        }
