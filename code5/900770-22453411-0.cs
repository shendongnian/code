    public int GetHashCode(FactorPayoffs obj)
    {
        unchecked
        {
                int hash = 17;
                hash = hash * 23 + obj.dtPrice.GetHashCode();
                hash = hash * 23 + obj.dtPrice_e.GetHashCode();
                if (obj.Factor != null)
                {
                    hash = hash * 23 + obj.Factor.GetHashCode();
                }
                if (obj.FactorGroup != null)
                {
                    hash = hash * 23 + obj.FactorGroup.GetHashCode();
                }
                return hash;
        }
    }
