	public class SomeAttribute : Attribute
	{
		public SomeAttribute(Type given)
		{
			Given = given;
			Required = typeof (INotifyDataErrorInfo);
		}
		public Type Given { get; set; }
		public Type Required { get; set; }
		public bool Valid()
		{
			return Required.IsAssignableFrom(Given);
		}
	}
	public enum TestEnum 
	{
		[Some(typeof(string))]
		Sms = 1,
		[Some(typeof(string))]
		Email = 2
	}
