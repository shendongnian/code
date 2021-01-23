    public abstract class BusinessBaseClass<T> : EntityBaseClass, IBusiness where T : InvestmentReturn, new()
    {
        public virtual InvestmentReturn GetReturn()
        {
            return new T();
        }
    }
