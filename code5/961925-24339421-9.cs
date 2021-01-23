    public class OnlineQuoteEngineStrategy : IQuoteEngineStrategy
    {
        public decimal QuoteMeHappy(Customer c) { // online related retrieval } 
    }
    public class OfflineQuoteEngineStrategy : IQuoteEngineStrategy
    {
       public decimal QuoteMeHappy(Customer c) { // offline related retrieval } 
    }
