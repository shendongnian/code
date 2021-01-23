    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IMessageService)
        {
            Connection = new Connection();
        }
		public Connection Connection
		{
			get { return GetValue<Connection>(ConnectionProperty); }
			set { SetValue(ConnectionProperty, value); }
		}
		public static readonly PropertyData ConnectionProperty = RegisterProperty("Connection", typeof(Connection));
		/*...*/
	}
