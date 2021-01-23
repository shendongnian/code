	public class EventDataSource
    {
        public string MyItemSource { get; set; }
        public EventDataSource()
        {
            MyItemSource = string.Empty;
        }
        
    }
	
	// Message class
	public class MyDataSourceMessage : MessageBase
    {
        public EventDataSource MyItemSource { get; set; }
        public MyDataSourceMessage(EventDataSource myItemSource)
        {
            MyItemSource = myItemSource;
        }
    }
	
	// Main ViewModel
	public class ViewModelOne : ViewModelBase
    {
		public NotifyViewModel() {}
        
		void testMessage()
        {
            EventDataSource msg = new EventDataSource() { MyItemSource = "magic message!"};
            Messenger.Default.Send(new MyDataSourceMessage(msg as EventDataSource));
        }
	}
	
	// My nested user control
	public class ViewModelTwo : ViewModelBase
    {
		
        public NotifyViewModel()
        {
            Messenger.Default.Register<MyDataSourceMessage>(this, (action) => ReceiveMessage(action));
        }
		
		private ObservableCollection<string> myProperty = new ObservableCollection<string>();
        public ObservableCollection<string> MyProperty
        {
            get { return myProperty; }
            set
            {
                myProperty: = value;
                RaisePropertyChanged(() => MyProperty);
            }
        }
		void ReceiveMessage(MyDataSourceMessage action)
        {
			// do something with the data
            MyProperty.Add(action.DGItemSource.ItemSource);
        }
	}
