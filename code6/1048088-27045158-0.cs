    //try this
    public class Order
    {
	    [Key]
        public int Id { get; set; }
        public virtual ICollection<OrderOrganisation> OrderOrganisations { get; set; }
    }
    public class Organisation
    {
	    [Key]
        public int Id { get; set; }
        public virtual ICollection<OrderOrganisation> OrderOrganisations { get; set; }
    }
    public class OrderOrganisation
    {
 	    [ForeignKey("Order"), Column(Order = 0)]
        public int? OrderId { get; set; }
	    [ForeignKey("Organisation"), Column(Order = 1)]
        public int? OrganisationId { get; set; }
	    [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
	    [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }
    }
