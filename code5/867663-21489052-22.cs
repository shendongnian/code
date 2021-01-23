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
					SetError( () => SomeProperty, ValidateSomeProperty()); // update validation for property
					RaisePropertyChanged( () => SomeProperty); // notify data bindings
				}
			}
		}
