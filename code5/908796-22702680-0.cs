    namespace YourEntityNameSpace
    {
        public partial class CustomerPurchase 
        {
            public double TotalAmount
            { 
                get
                {
                    // your code goes here to calculate, for sample:
                    return UnitPrice * Amount;
                }
            }
        }
    }
