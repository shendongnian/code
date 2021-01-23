    public class Product {
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
                    throw new ArgumentNullException("name must not be null");
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
