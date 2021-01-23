    public class CalculationType
    {
        public long ID { get; set; }
        public string UnitName { get; set; }
        public int Point { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        [ForeignKey("Indicator")]
        public string IndicatorId { get; set; } //this is the foreign key, i saw in your database is: Indicator_ID, avoid this, rename it to IndicatorId
    
        public virtual Indicator Indicator { get; set; }
        public virtual IList<Сalculation> Calculations { get; set; }
    }
