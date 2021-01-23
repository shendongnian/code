    public partial class SupplyPointMeter
    {        
        public int SupplyPointMeterId { get; set; }
        public int SupplyPointId { get; set; }
        public virtual SupplyPoint SupplyPoint { get; set; }
    }
    public partial class SupplyPoint
    {
        public int SupplyPointId { get; set; }
        public virtual ICollection<SupplyPointMeter> SupplyPointMeters { get; set; }
    }
