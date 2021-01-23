    public class SupplyPointMeter
    {
        public int Id { get; set; }
        public virtual SupplyPoint SupplyPoint { get; set; }
    }
    
    public class SupplyPoint
    {
        public int Id { get; set; }
        public virtual ICollection<SupplyPointMeter> SupplyPointMeters { get; set; }
    }
