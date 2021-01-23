    public class PayCode
    {
      public virtual int PayCodeId { get; set; }
      public virtual string Name { get; set; }
      public virtual CombinedPayCode CombinedPayCode {get;set;}
    }
    public class CombinedPayCode
    {
      public virtual int CombinedPayCodeId { get; set; }
      public virtual int PayCodeId { get; set; }
      public virtual ICollection<PayCode> PayCodes { get; set; }
      public virtual string Name { get; set; }
    }
