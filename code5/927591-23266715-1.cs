    public class Stock : Operand
    {
        public double StockValue { get; set; }
        protected internal override void AddPropertiesToObject(dynamic o)
        {
            // I decided to ignore the base class Id and Name
            // adding them would be trivial, but may not be what you need since 
            // it would overwrite the base values...
            // To add them you would have to wrap this virtual method call with
            // a call to a function doing the insertion in the base class 
            o.StockValue = StockValue;
        }
    }
