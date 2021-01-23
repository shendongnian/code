    public abstract class SupportedPaymentMethod
    {
        protected internal SupportedPaymentMethod() { }
    }
    
    public sealed class Check : SupportedPaymentMethod
    {
        public int CheckNumber { get; private set; }
        
        public Check(int checkNumber)
    	 : base()
    	{
            CheckNumber = checkNumber;
        }
    }
    
    public sealed class CreditCard : SupportedPaymentMethod
    {
        public CreditCard()
    	 : base()
    	{ }
    }
    
    public abstract class Payment<T>
        where T : SupportedPaymentMethod
    {
        public T Method { get; private set; }
    
        protected internal Payment(T method)
    	{
    	    Method = method;
    	}
    }
    
    public sealed CheckPayment : Payment<Check>
    {
        public CheckPayment(Check check)
    	 : base(check)
    	{ }
    }
    
    public sealed CreditCardPayment : Payment<CreditCard>
    {
        public CreditCardPayment(CreditCard creditCard)
    	 : base(creditCard)
    	{ }
    }
