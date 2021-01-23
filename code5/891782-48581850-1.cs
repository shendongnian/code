    public class CycleTest
    {
        [MaxLength(5)]
        [Key, Column(Order = 0)]
        public string Action { get; set; }
    
        [Key, Column(Order = 1)]
        public int Cycle { get; set; }
    
        public DateTime Created { get; set; }
    
        [ForeignKey("Case"), Column(Order = 2)]
        public string BusinessSystemId { get; set; }
    
        [ForeignKey("Case"), Column(Order = 3)]
        public int CaseId { get; set; }
    
        public virtual Case Case { get; set; }
    }
