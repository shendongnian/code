    // test data
    List<PointF> oData = new List<PointF>();  // orginal data values
    List<PointF> D0 = new List<PointF>();     // reduced smoothed data
    List<PointF> D1 = new List<PointF>();     // 1st derivative
    List<PointF> D2 = new List<PointF>();     // 2nd derivative
    List<PointF> M = new List<PointF>();      // reasonably large values from D2
    int N1 = 255;            // number of data points with slope S1
    int N2 = 15;             // number of data points between S1 and S2
    int N3 = 40;             // number of data points with slope S2
    int n = N2 / 3;          // grouping number
    float S1 = 0.2f;         // Slope 1
    float S2 = 1.3f;         // Slope 2
    float S12 = (S2 - S1) / N2; 
    float P1y = N1 * S1;
    float cutOff = 2f;      // cutoff value to detemine 'reasonably' large slope changes
    int roughness = 10;
    float smoothness = 15f;
    // create the data points
    for (int i = 1; i <= N1; i++) oData.Add(new PointF(
             i, i * S1 + (R.Next(roughness) - roughness/2) / smoothness));
    for (int i = 1; i <= N2; i++) oData.Add(new PointF(
             i + N1, P1y + i * S12 + (R.Next(roughness) - roughness/2) / smoothness));
    for (int i = 1; i <= N3; i++) oData.Add(new PointF(
             i + N1 + N2, P1y + i * S2 + (R.Next(roughness) - roughness/2) / smoothness));
    // display them
    chart1.ChartAreas.Add("data");
    Series s = chart1.Series.Add("data");
    s.ChartType = SeriesChartType.Line;
    foreach (PointF p in oData) s.Points.Add(new DataPoint(p.X, p.Y));
    // smoothen the data
    for (int i = 1; i < oData.Count / n; i++) 
    {
        float ysum = 0.0f;
        for (int j = 0;j<n; j++) ysum += oData[i*n+j].Y;
        D0.Add(new PointF(i, ysum/n));
    }
    // 1st derivative
    for (int i = 1; i < D0.Count; i++) D1.Add(new PointF(i, D0[i - 1].Y - D0[i].Y));
    // 2nd derivative
    for (int i = 1; i < D1.Count; i++) D2.Add(new PointF(i, D1[i - 1].Y - D1[i].Y));
    // collect 'reasonably' large values from D2
    foreach (PointF p in D2) if (Math.Abs(p.Y / cutOff ) > 1) M.Add(p);
    // our target is n after the last one
    int targetX = (int) (M[M.Count -1 ].X * n) + n;
    // display as annotation
    VerticalLineAnnotation LA = new VerticalLineAnnotation();
    LA.LineColor = Color.Red;
    LA.AnchorDataPoint = s.Points[targetX];
    LA.IsInfinitive = true;
    LA.ClipToChartArea = "data";
    chart1.Annotations.Add(LA);
