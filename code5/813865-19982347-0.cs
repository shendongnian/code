    public class PromotionalCodeEqualityComparer
        : IEqualityComparer<PromotionalCodeValue>
    {
        public bool Equals(PromotionalCodeValue x, PromotionalCodeValue y)
        {
            return x.Value == y.Value;
        }
        
        public int GetHashCode(PromotionalCodeValue obj)
        {
            return obj.Value != null ? obj.Value.GetHashCode() : 0;
        }
    }
