    public class MyViewModel : ViewModelBase
	{
		private string someProperty;
	
		public string SomeProperty
		{
			get
			{
				return someProperty;
			}
			set
			{
				if(someProperty != null)
				{
					someProperty = value;
					SetError("SomeProperty", ValidateSomeProperty());
				}
			}
		}
		
		private string ValidateSomeProperty()
		{
			if(String.IsNullOrEmpty(SomeProperty))
				return "Value is required";
			return null;
		}
	}
