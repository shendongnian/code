	using System.Collections.ObjectModel;
	using System.ComponentModel;
	namespace MultipleDataGrid
	{
		public class ViewModel : INotifyPropertyChanged
		{
			public ObservableCollection<string> ServerLog { get; private set; }
			public ViewModel()
			{
				Something.Start();
				Something.Log.CollectionChanged += (s, e) =>
					{
						ServerLog = Something.Log;
						RaisePropertyChanged("ServerLog");
					};
			}
			public event PropertyChangedEventHandler PropertyChanged;
			public void RaisePropertyChanged(string propName)
			{
				var pc = PropertyChanged;
				if (pc != null)
					pc(this, new PropertyChangedEventArgs(propName));
			}
		}
	}
