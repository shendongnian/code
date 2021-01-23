    public class Customer
    {
      private Customer Parent {get; private set;}
    
      private int _id;
      public int CustomerID
      {
        get { return Parent == null ? _id : Parent.CustomerID; }
        set
        {
          if(Parent != null)
            throw new InvalidOperationException("...");
    
          _id = value;
        }
    
        public Customer()
        {
        }
    
        public static Customer Clone(Customer parent)
        {
          return new Customer{Parent = parent};
        }
    }
