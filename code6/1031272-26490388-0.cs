	public class Parent : IParent
	{
		public int ParentId { get; set; }
		public Child Child { get; set; }
	}
	public class Child : IChild
	{
		public int ChildId { get; set; }
		public Parent Parent { get; set; }
	}
	
