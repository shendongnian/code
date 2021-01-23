    [DataContract]
    public class TransactionDataTransferObject 
    {
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    
        public string MediaName { get; set; }
        
        public Guid MediaId { get; set; }
        
        public string UserName { get; set; }
        
        public Guid UserId { get; set; }
        
        [Display(Name = "Description")]
        public string Discriminator { get; set; }
    
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }    
    
    }
