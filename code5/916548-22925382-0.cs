    for (int i = 0; i < 1; i++)
    {
        chart1.Series[0].Points.AddXY("Jan", i + 10);
        chart1.Series[0].Points.AddXY("Feb", i + 15);
    }
    // Create a new legend called "Legend1".
    chart1.Legends.Add(new Legend("Legend1"));
    // Set title
    chart1.Legends["Legend1"].Title = "My legend";
    // Assign the legend to Series1.
    chart1.Series["Series1"].Legend = "Legend1";
    chart1.Series["Series1"].IsVisibleInLegend = true;
