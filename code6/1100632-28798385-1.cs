    public class Product {
        
        //Note: Using ProductName rather than string would be helpful
        //to protect further invariants (e.g. name cannot be empty string)
        private string _name;
    
        public Product(string name) {
            Name = name;
        }
    
        public string Name {
            get {
                return _name;
            }
    
            private set {
                if (value == null) {
                    throw new ArgumentNullException("A product must be named");
                }
    
                _name = value;
            }
        }
    
        public void rename(string newName) {
            string oldName = Name;
    
            Name = newName;
    
            //Assume the entity has the supporting code for a  unique identifier
            //productId
            DomainEvents.Raise(new ProductRenamed(productId, oldName, newName));
        }
    }
