    var stat = from row in ds.Tables[0].AsEnumerable()
    group row by new
    {
      Col1 = row["Name"],
    } into TotalCount
    select new
    {
      ActionName = TotalCount.Key.Col1,
      ActionCount = TotalCount.Count(),
     };
