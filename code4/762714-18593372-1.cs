    public override Expression<Func<CustomerCustomerType, bool>> WhereFilter
    {
        get {
            var baseResult = base.WhereFilter;
            if (baseResult == null) {
                return x => x.CustomerID == 1;
            } else {
                return base.WhereFilter.And(x => x.CustomerID == 1);
            }
        }
    }
