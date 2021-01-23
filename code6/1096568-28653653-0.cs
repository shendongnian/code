    public class Money
    {
        readonly decimal _amount;
        readonly string _currency;
        public decimal Amount {get{return _amount;}}
        public decimal Currency {get{return _currency;}}
    
        public Money(decimal amount, string currency)
        {
            //validity checks here and then
            _amount=amount;
            _currency=currency;
        }
    }
