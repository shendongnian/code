    public class MainViewModel : INotifyPropertyChanged
	{
		// INotifyPropertyChanged implementation
		
		public ICommand GetAllActionLogsBetweenDatesCommand { get; set; }
		  
		public MainViewModel()
		{
			GetAllActionLogsBetweenDatesCommand = new RelayCommand(GetAllActionLogsBetweenDates_Execute);
		}
		private void GetAllActionLogsBetweenDates_Execute(object parameter)
		{
			try
			{
				var stringList = parameter as string[];
				DateTime fromDate = DateTime.Parse(stringList[0]);
				DateTime toDate = DateTime.Parse(stringList[1]);
                // Query the data.
			}
			catch (Exception ex)
			{
			
			}
		}
	}
