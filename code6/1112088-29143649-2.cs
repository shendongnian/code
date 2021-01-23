    public class RangeEntry
    {
        public RangeEntry(int upperValue, float weight)
        {
            UpperValue = uperValue;
            Weight = weight;
        }
        public int UpperValue { get; set; }
        public float Weight { get; set; }
    }
    public class RangeWeights
    {
        private List<RangeEntry> _ranges = new List<RangeEntry>
        {
            new RangeEntry(30, 1.2f),
            new RangeEntry(40, 1.8f),
            new RangeEntry(50, 1.9f),
        }
        public float GetWeight(int value)
        {
            // If you pre-sort the ranges then you won't need the below OrderBy
            foreach (var r in _ranges.OrderBy(o => o.UpperValue)) 
            {
                if (value <= r.UpperValue)
                    return r.Weight;
            }
            // Range not found, do whatever you want here
            throw new InvalidOperationException("value not within in any valid range");
        }
    }
