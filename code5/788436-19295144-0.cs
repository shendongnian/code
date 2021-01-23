    var groups = from row in allDataView.Table.AsEnumerable()
                             group row by new { Convert.ToDateTime(row["DateOfData"]).Hour, Convert.ToDateTime(row["DateOfData"]).Date } into g
                             select new
                             {
                                 FirstDate = g.First()["DateOfData"],
                                 FirstValue = g.First()["Value"],
                                 LastDate = g.Last()["DateOfData"],
                                 LastValue = g.Last()["Value"]
                             };
    
    
                var result = groups.Select(grp => Convert.ToDouble(grp.FirstValue) - Convert.ToDouble(grp.LastValue));
