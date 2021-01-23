    List<string> groupBys = new List<string>();
    if (AName != "")
    {
        groupBys.Add(AName);
    }
    if (MName != "")
    {
        groupBys.Add(MName);
    }
    var DistinctTable = SourceTable.DefaultView.ToTable(true, groupBys.ToArray());
