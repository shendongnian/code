    internal class MyData
    {
      public static MyData CreateInstance( string json )
      {
        DateTime   unixEpoch = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 );
        ParsedJson record    = ParsedJson.CreateInstance( json );
        MyData     instance = new MyData
                              {
                                TimeStamp = unixEpoch.AddSeconds( (double)record.Timestamp ) ,
                                Bids      = record.Bids.Select( x => new BidAsk( x[0] , x[1] ) ).ToArray() ,
                                Asks      = record.Bids.Select( x => new BidAsk( x[0] , x[1] ) ).ToArray() ,
                              } ;
        return instance;
      }
      
      public DateTime TimeStamp { get; private set; }
      public BidAsk[] Bids      { get; private set; }
      public BidAsk[] Asks      { get; private set; }
      
      private MyData()
      {
        return;
      }
      
      public class BidAsk
      {
        public decimal Price  { get; private set; }
        public decimal Amount { get; private set; }
        public BidAsk( decimal price , decimal amount )
        {
          this.Price = price;
          this.Amount = amount;
          return;
        }
      }
    }
