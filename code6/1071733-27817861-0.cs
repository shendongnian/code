	public interface MyClassInterface
	{
		BasePropertyClass MyPropThatMustInheritBasePropertyClass { get; set;}
	}
	public class MyClass : MyClassInterface
	{
		private MyPropClass _actualProperty;
		public BasePropertyClass MyPropThatMustInheritBasePropertyClass 
		{ 
			get { return _actualProperty; } 
			set { _actualProperty = (MyPropClass)value; }
		}
	}
