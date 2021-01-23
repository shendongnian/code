    var topLevel1 = resultRows
    .GroupBy(g => g["CustomerAccountType"])
    .ToDictionary(
        g => g.Key,                                
        g => { return g.ToList() as object; }).Union(new Dictionary<string, object> {     {"somekey", "somevalueorobject"}).ToDictionary(x=>x.Key,x=>x.Value);
