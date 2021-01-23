	public class Wrapper
	{
		public Data Data { get; set; }
	}
	
	public class Data
	{
		public List<AddressWrapper> Addresses { get; set; }
	}
	
	public class AddressWrapper
	{
		public string Model { get; set; }
		public Address Address { get; set; }
	}
	
	public class Address 
	{
		public GraphOptConsumption GraphOptConsumption { get; set; }
	}
	
	public class GraphOptConsumption
	{
		public string OptType { get; set; }
	}
