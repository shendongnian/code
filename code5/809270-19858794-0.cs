    public class MyClass
	{
		[XmlElement("Customer")]
		public Customer cust { get; set; } 
		
	}
	public class Customer
	{
		[XmlElement("CustId")]
		public int Id { get; set; }
		[XmlElement("CustName")]
		public string Name { get; set; }
	}
