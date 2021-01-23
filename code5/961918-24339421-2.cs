    public class InsurancePackage 
    {
      
      public decimal QuoteMeHappy(Customer c)
      {
          return QuoteEngine.GetQuotingEngine(c).QuoteMeHappy(c);
      }
    }
