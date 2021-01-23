    public class InsurancePackage 
    {
      
      public decimal RiskQuote(Customer c)
      {
           return QuoteEngine.GetQuotingEngine(c).QuoteMeHappy(c);
      }
    }
