	public class EntityBase
	{
		public Guid Id { get; protected set; }
		
		//logic with Id
	}
	
	public class Tenant : EntityBase
	{
	     public string Name { get; set; }
	}
