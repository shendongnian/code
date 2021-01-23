	public class Parent
	{
		public ParentNested n;
		
		public Parent()
		{
			 n = new ParentNested(this);	
		}
	}
	
	public class Nested
	{
		public Nested(object owner)
		{
			// return "Parent" ???
			string ParentName = owner.GetType().Name;
		}
	}
	
	public class ParentNested : Nested
	{
		public ParentNested(object owner) : base(owner) {}
	}
