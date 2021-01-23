    foreach (DataColumn col in dt.Columns)
    {
        string line = dtr.GetValue(rt).ToString();
        idList.Add(line);
        rt++;
    }
