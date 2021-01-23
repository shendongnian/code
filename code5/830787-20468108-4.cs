	public interface IBaseThing {}
	public interface IChildThing : IBaseThing {}
	internal abstract class Base<T> where T : IBaseThing
	{
		public abstract T Thing {get;}
	}
	internal class Concrete:Base<IChildThing>
	{
		public override IChildThing Thing
		{
			get
			{
				return GetChildThing();
			}
		 }
		 
		 public IChildThing GetChildThing()
		 {  
			// Your impelementation here...
			return null;
		 }
	}
