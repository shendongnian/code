    public class PromotionalCodeValueEqualityComparer :
        IEqualityComparer<PromotionalCodeValue>
    {
        public bool Equals(PromotionalCodeValue x, PromotionalCodeValue y)
        {
            return x.Value == y.Value;
        }
        public int GetHashCode(PromotionalCodeValue x)
        {
            return x.Value.GetHashCode();
        }
    }
