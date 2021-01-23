    public class UnionResult 
    {
        string Type { get; set; }
        ...
    }
    var results = dbContext.Table.Select(r => new UnionResult { Type = "Ledger", ... });
