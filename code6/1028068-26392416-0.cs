     public class PurchaseRecordViewModel
     {
        public DateTime Date {get;set;}
        public decimal Cost {get;set;}
        // .... some other properties
        public PurchaseRecordsViewModel(PurchaseRecordsDomainModel domainModel)
        {
           Date = domainModel.Date;
           Cost = domainModel.Cost;
           // .... some other property mappings
        }
     }
