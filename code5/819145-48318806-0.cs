    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class ReferenceTypeAttribute : Attribute
	{
		private readonly Type _type;
		public ReferenceTypeAttribute(Type type)
		{
			_type = type;
		}
	}
