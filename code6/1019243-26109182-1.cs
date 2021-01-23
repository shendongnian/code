    public class Customer
    {
        public Lazy<string> CustAddr { get; private set; }
        public Lazy<double> CustAcct { get; private set; }
        public Lazy<string> CustInvoice { get; private set; }
        public Customer()
        {
            CustAddr = new Lazy<string>(GetCustAddr);
            CustAcct = new Lazy<double>(GetCustAcct);
            CustInvoice = new Lazy<string>(GetCustInvoice);
        }
    }
