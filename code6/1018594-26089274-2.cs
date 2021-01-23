    var dt = new DataTable();
    dt.Columns.Add(" "); // for the day
    for (int i = 1; i <= 8; i++)
        dt.Columns.Add("Per-" + i);
    DataRow tue = dt.Rows.Add();
    tue.SetField(0, "Tue");
    for (int i = 1; i <= 8; i++)
        tue.SetField("Per-" + i, input);
    DataRow wed = dt.Rows.Add();
    wed.SetField(0, "Wed");
    for (int i = 1; i <= 8; i++)
        wed.SetField("Per-" + i, input);
    DataRow thu = dt.Rows.Add();
    thu.SetField(0, "Thu");
    for (int i = 1; i <= 8; i++)
        thu.SetField("Per-" + i, input);
    DataRow fri = dt.Rows.Add();
    fri.SetField(0, "Fri");
    for (int i = 1; i <= 8; i++)
        fri.SetField("Per-" + i, input);
    DataRow sat = dt.Rows.Add();
    sat.SetField(0, "Sat");
    for (int i = 1; i <= 8; i++)
        sat.SetField("Per-" + i, input);
