	public partial class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long User_ID { get; set; }
		[StringLength(50)]
		public string Username { get; set; }
		[InverseProperty("User")]
		public virtual List<User_Document> Documents { get; set; }
	}
