    public class RequiredResourceAttribute : System.Attribute
    {
        public int Quantity { get; set; } 
  
        public RequiredResourceAttribute( int qty ){ 
           Quantity = qty;
        }
    }
    public class RequiredWoodAttribute : RequiredSourceAttribute
    {
        public RequiredWoodAttribute ( int qty ) : base(qty ){ 
        }
  
    }
