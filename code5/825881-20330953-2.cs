    var prisonGroups = ((DataTable)gvData.DataSource).AsEnumerable()
        .GroupBy(row => row.Field<string>("prison1"));
    int countC = prisonGroups
       .Where(g => g.Key == "c")
       .Sum(g => g.Count());
    int countD = prisonGroups
       .Where(g => g.Key == "d")
       .Sum(g => g.Count());
