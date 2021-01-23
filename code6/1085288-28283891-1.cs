    // populates IEnumerable
    public class Customer
    {
        public Customer()
        {
          this.Names = new List<string>();
        }
    
        public IEnumerable<string> Names {get; set;}
    
    }
