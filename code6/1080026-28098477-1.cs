    var results = items.GroupBy(x => x.TransactionType).ToDictionary(x => x.Key, x => x.Sum(y => y.TransactionValue));
    var totals = new Totals
    {
        TotalIncoming = results["Income"],
        TotalOutgoing = results["Outgoing"]
    };
Might I suggest instead of using a string for your TransactionType using an enum instead? For example,
    public enum TransactionType
    {
        Income,
        Outgoing,
    }
