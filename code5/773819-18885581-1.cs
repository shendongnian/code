    public class MAcrossLong : Strategy
    {
       private int variable1 = 0;
       private int variable2 = 0;
       private Dictionary<string, StockEntry> _stocks;
       protected override void Initialize()
       {
          _stocks.Add("ABC", new StockEntry { Name = "ABC", Period = PeriodType.Minute, Value = 5, Count = 0 } );
       }
       protected override void OnBarUpdate()
       {
          _stocks["ABC"].Name = "new name"; // Or some other code with _stocks
       }
    }
