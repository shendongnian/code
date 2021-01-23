    public class Order
    {
        public int Id { get; set; }
        public virtual ICollection<Organisation> OrderOrganisations { get; set; }
    }
    public class Organisation
    {
        public int Id { get; set; }
        public virtual ICollection<Order> OrderOrganisations { get; set; }
    }
