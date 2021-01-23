    var sortedTable = testTableData.AsEnumerable()
    .Where(r => r.Field<string>("FValue") != "")
    .GroupBy(r => new
     {
         SID = r.Field<int>("SID"),
         SName = r.Field<string>("SName"),
         EID = r.Field<int>("EID"),
         EFID = r.Field<int>("EFID")   
     })
    .OrderBy(g => g.Key.SID)
    .ThenBy(g => g.Key.SName)
    .ThenBy(g => g.Key.EID)
    .ThenBy(g => g.Key.EFID)
    .Select(g => new {
                            SID = g.Key.SID,
                            SName = g.Key.SName,
                            EID = g.Key.EID,
                            EFID = g.Key.EFID,    
                            Avg = g.Average(x => decimal.Parse(x.Field<string>("EPoints"))),
                            YesCount = g.Sum(x => x.Field<string>("FValue") == "Y" ? 1 : 0),
                            NoCount = g.Sum(x => x.Field<string>("FValue") == "N" ? 1 : 0)
                        });
