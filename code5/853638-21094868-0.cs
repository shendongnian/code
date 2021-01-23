    public class MyClass
    {
        Entity.Base.Product Product { get; private set; }
        Entity.Base.Version Version { get; private set; }
        Entity.Base.Customer Customer { get; private set; }
        Entity.Base.Error Error { get; private set; }
    
        public MyClass(
                    Entity.Base.Product product,
                    Entity.Base.Version version,
                    Entity.Base.Customer customer,
                    Entity.Base.Error error)
        {
            this.Product = product;
            this.Version = version;
            this.Customer = customer;
            this.Error = error;
        }
    }
