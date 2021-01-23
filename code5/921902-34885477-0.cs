    public class Carrier : Entity
    {
        public Carrier()
        {
             this.Id = Guid.NewGuid();
        }  
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
