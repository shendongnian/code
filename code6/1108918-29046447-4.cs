    public class Person()
    {
        public Person()
        {
            Addresses = new Collection<Address>();
        }
    
        public int Id {get; set;}
        public string Name {get; set;}
        public virtual Collection<Address> Addresses {get; set;}
    }
