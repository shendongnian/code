    public abstract class BusinessBaseClass<T, U> : EntityBaseClass, IBusiness
        where T : InvestmentReturn<U>, new()
        where U : IBusiness
    {
        public double GrossRevenue { get; set; }
        public virtual InvestmentReturn GetReturn()
        {
            return new T { Business = (U)(object)this };
        }
    }
