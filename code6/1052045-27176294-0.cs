    // propare a few short names
    ChartArea CA = chart1.ChartAreas[0];
    Series S1 = chart1.Series[0];
    // this would be option one:
    S1.IsValueShownAsLabel = true;
    // we clear any previous CustomLabels
    CA.AxisY.CustomLabels.Clear();
    // we create a version of our points collection which sorted  by Y-Values:
    List<DataPoint> ptS = S1.Points.OrderBy(x => x.YValues[0]).ToList();
    // now, for option three we add the custom labels:
    for (int p = 0; p < ptS.Count; p++)
    {
        CustomLabel L = new CustomLabel(ptS[p].YValues[0] - 0.5, 
                                        ptS[p].YValues[0] + 0.5,  
                                        ptS[p].YValues[0].ToString("##0.0000"), 
                                        0, LabelMarkStyle.None);
        CA.AxisY.CustomLabels.Add(L);
        // this is option two: tooltips for each point
        ptS[p].ToolTip = ptS[p].YValues[0].ToString("##0.0000");
    }
