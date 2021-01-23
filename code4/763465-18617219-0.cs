    var matches = (
      from entry in table
      where entry.StockIndexId == StockIndexId
      where Companies.Contains(entry.StockCompanyId)
      select entry).ToList();
    var ResponseValues = new List<DTO>();
    ResponseValues.Add(new DTO {
      Quarter = 0,
      AggregatedValue = matches.Sum(
        match => match.Q0 ?? 0
      ) / matches.Length
    });
    ResponseValues.Add(new DTO {
      Quarter = 1,
      AggregatedValue = matches.Sum(
        match => match.Q1 ?? 0
      ) / matches.Length
    });
    ... snip ...
    ResponseValues.Add(new DTO {
      Quarter = 20,
      AggregatedValue = matches.Sum(
        match => match.Q20 ?? 0
      ) / matches.Length
    });
