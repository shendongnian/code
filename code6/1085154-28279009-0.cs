    public class MyType
    {
        int MonthNumber {get;set;}
        string Category {get;set;}
        int OrdersCount {get;set;}
    }
    public List<MyType> GetMethod()
    {
        var categoryCounts =
               (from r in reqCount
                group r by new
                {
                    r.First,
                    r.Second
                }
                    into g
                    select new MyType()
                    {
                        MonthNumber = g.Key.First,
                        Category = g.Key.Second,
                        OrdersCount = g.Count()
                    }).OrderBy(m => m.MonthNumber).ThenBy(c => c.Category).ToList();
        return categoryCounts;
    }
