	public class Parent : IParent
	{
		public int ParentId { get; set; }
		public IChild Child { get; set; }
	}
	public class Child : IChild
	{
		public int ChildId { get; set; }
		public IParent Parent { get; set; }
	}
