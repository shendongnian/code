    string input = "Artificial Intelligence Faculty: John Doe Room: LS110";
    var dt = new DataTable();
    for (int i = 1; i <= 8; i++)
        dt.Columns.Add("Per-" + i);            
    DataRow tue = dt.Rows.Add();
    for (int i = 1; i <= 8; i++)
        tue.SetField("Per-" + i, input);
    DataRow wed = dt.Rows.Add();
    for (int i = 1; i <= 8; i++)
        wed.SetField("Per-" + i, input);
    DataRow thu = dt.Rows.Add();
    for (int i = 1; i <= 8; i++)
        thu.SetField("Per-" + i, input);
    DataRow fri = dt.Rows.Add();
    for (int i = 1; i <= 8; i++)
        fri.SetField("Per-" + i, input);
    DataRow sat = dt.Rows.Add();
    for (int i = 1; i <= 8; i++)
        sat.SetField("Per-" + i, input);
