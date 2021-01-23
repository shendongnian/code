	public class ApplicationUser : IdentityUser
    {
		//...
		
		public int InstitutionId { get; set; }
		
        [Display(Name="Institution")]
		[ForeignKey("InstitutionId")] //This attribute isn't strictly necessary but adds clarity
		public Institution Institution { get; set; }
	}
	
	public class Institution
	{
		[Key]
		public int Id { get; set; }
		
        public string Name { get; set; }
        public string Description { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
