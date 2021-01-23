    public class Transaction {
      public int ID { get; set; }
      public double Amount { get; set; }
      public virtual ICollection<Tender> Tenders { get; set; }
    }
    
    from T in context.Transactions
    select new {
      Amount = T.Amount,
      TenderTypes = T.Tenders.Select(t => t.TenderType)
    }
