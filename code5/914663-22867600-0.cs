    public class ConsumableThreshold : IEqualityComparer<ConsumableThreshold>
        {
            public int ThresholdType { get; set; }
            public int ThresholdValue { get; set; }
    
            public int ConsumableType { get; set; }
            public int ConsumableVariantID { get; set; }
            public int ManufacturerID { get; set; }
            public int ModelID { get; set; }
    
            public bool Equals(ConsumableThreshold x, ConsumableThreshold y)
            {
                return x.ThresholdType == y.ThresholdType;
            }
    
            public int GetHashCode(ConsumableThreshold obj)
            {
                return obj.ThresholdType.GetHashCode();
            }
        }
