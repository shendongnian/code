    chart1.Titles.Add("TiltelBox");
    Title T = chart1.Titles[0];
    ChartArea CA = chart1.ChartAreas[0];
    T.DockedToChartArea = CA.Name;
    T.BackColor = Color.Wheat;
    T.Docking = Docking.Top;
    T.IsDockedInsideChartArea = true;
    ElementPosition EP = T.Position;
    T.Position = new ElementPosition
                    (EP.X + 10f, EP.Y -0.5f, EP.Width + 83.5f, EP.Height + 9f);
