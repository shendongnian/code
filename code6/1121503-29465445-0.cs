    public static class StaticData
    {
        public static readonly List<Customers> _Customers = new List<Customers>();
    
        public static List<Customers> CustomerList
        {
             get 
             {
                if (_Customers.Count < 1) 
                {
                      //Load Customer data
                }
                return _Customers;
             }
        }
    }
    
    public class Form1
    {
        private List<Customers> new_customer = null;
        public Form1()
        {
            this.new_customer = StaticData.CustomerList;
        }
    }
    
    public class Current_Customers
    {
        private List<Customers> new_customer = null;
    
        public Current_Customers()
        {
            this.new_customer = StaticData.CustomerList;
        }
    }
