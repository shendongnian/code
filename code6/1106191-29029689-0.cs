    public class Offer
    {
      public int Id { get; set; }
      public virtual OfferState State { get; set }
    }
     
    public class OfferState
    {
      public int OfferId { get; set; }
      public string Notes { get; set; }
    }
    
    public class AcceptedOfferState : OfferState
    {
      public DateTimeOffset AcceptDate { get; set; }
    }
    
    public class DeclinedOfferState : OfferState
    {
      public DateTimeOffset DeclinedDate { get; set; }
    }
