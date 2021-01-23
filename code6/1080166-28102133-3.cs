     public class Customers
    {
      
        public List<int> CustomerIds { get; set; }
        public Customers()
        {
            CustomerIds = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                CustomerIds.Add(i);
            }
        }
        
    }
