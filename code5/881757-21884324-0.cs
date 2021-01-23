    [Table("Events")]
    public class StgEvent
    {
        public Nullable<DateTime> WebServiceCallDate { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }
        [MaxLength(100)]
        public string Lookup { get; set; }
        [MaxLength(510)]
        public string Name { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        [MaxLength(510)]
        public string Client { get; set; }
        [MaxLength(510)]
        public string VenueName { get; set; }
    }
