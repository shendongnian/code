	//CustomerChange class
	public class CustomerChange
    {
        public int Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Relationships
        public virtual Customer Customer { get; set; }
    }
	//Mapping details for CustomerChange class
    public class CustomerChangeMap : EntityTypeConfiguration<CustomerChange>
    {
        public CustomerChangeMap()
        {
            this.HasKey(c => new { c.Id, c.ChangeDate });
            //Relationship mappings
            this.HasRequired(cm => cm.Customer)
                .WithMany(c => c.CustomerChanges)
                .HasForeignKey(cm => cm.Id);
        }
    }
	
