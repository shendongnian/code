    public class Note
    {
        [Key]
        public int ID { get; set; }
        public DateTime notetimestamp { get; set; }
        public string notestring { get; set; }
        
        [ForeignKey("Order)]
        public string woNum { get; set; }
        public virtual WorkOrder Order{get;set;}
    }
