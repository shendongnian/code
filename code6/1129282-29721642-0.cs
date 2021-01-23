	public partial class User_Document
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long User_Document_ID { get; set; }
		public long User_ID { get; set; }
		[ForeignKey("User_ID")]
		[InverseProperty("Documents")]
		public virtual User User { get; set; }
	}
