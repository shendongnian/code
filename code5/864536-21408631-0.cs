    public class LegalTransactionRec
    {
     public string AccountNumber { get; set; }
     public string CostAmount { get; set; }
     public string SSN { get; set; }
     public int BatchID { get; set; }
     public Attorney Attorney { get; set; }
     public DateTime TransactionDate { get; set; }
     public string Description { get; set; }
     public int TransactionCode { get; set; }
    }
