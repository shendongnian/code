    public class QuoteEngine 
    {
        
        public static IQuoteEngineStrategy GetQuotingEngine(Customer c) 
        {
            if (c.Age < 25 )
            {
               return new OnlineQuoteEngineStrategy();
            }
            else
            {
               return new  OfflineQuoteEngineStrategy();
            }
        }
