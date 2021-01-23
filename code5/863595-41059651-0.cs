	[Serializable]
	[XmlType(TypeName = "CoreAccount")]
	public abstract class Account
	{
		[XmlElement(IsNullable = false)]
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public DateTime OpenDate { get; set; }
	}
	
