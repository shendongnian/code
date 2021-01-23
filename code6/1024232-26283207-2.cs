    ...
    let max = (from g in x
               group g by g.RecordedDateTime into g
               orderby g.Count() descending
               select g).FirstOrDefault()
    select new
    {
      ...
      Max = max.Count(),
      DateTime = max.Key
    };
