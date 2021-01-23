    public class AddRefundsViewModel
    {
      public RefundModel Refund { get; set; }
    }
 
    public class RefundModel
    {
      public string Reason { get; set; }
      public Decimal Amount { get; set; }
    }
