    class CostPageParentEqualityComparer : IEqualityComparer<CostPageParent>
    {
        public bool Equals(CostPageParent x, CostPageParent y)
        {
            if (x == null)
                return y == null;
            if (object.ReferenceEquals(x, y))
                return true;
            return 
                x.BillTypeDirect == y.BillTypeDirect &&
                x.BillTypeWarehouse == y.BillTypeWarehouse &&
                ...
        }
        public int GetHashCode(CostPageParent obj)
        {
            var x = 31;
            x = x * 17 + obj.BillTypeDirect.GetHashCode();
            x = x * 17 + obj.BillTypeWarehouse.GetHashCode();
            ...
            return x;
        }
    }
