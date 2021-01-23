	public class Staff
	{
		[Key]
		public Guid Id { get; set; }
		
		[ForeignKey("Contact")]
		public Guid ContactId { get; set; }
		public Contact Contact { get; set; }
	}
	public class Contact
	{
		[Key]
		public Guid Id { get; set; }
		
		public string Name { get; set; }
		
		[ForeignKey("Dog")]
		public Guid DogId { get; set; }
		public Dog Dog { get; set; }
	}
	public class Dog
	{
		[Key]
		public Guid Id { get; set; }
	}
