	using System.Collections.ObjectModel;
	using System.Windows.Input;
	using Cinch;
	namespace TestWPF
	{
		public class ViewModel : ViewModelBase
		{
			public ICommand TestCommand { get; private set; }
			public ObservableCollection<string> OuterCollection { get; private set; }
			public string OuterListBoxSelectedItem { get; set; }
			public ObservableCollection<string> InnerCollection { get; private set; }
			public string InnerListBoxSelectedItem { get; set; }
			public ViewModel()
			{
				OuterCollection = new ObservableCollection<string> { "Outer 1", "Outer 2", "Outer 3", "Outer 4" };
				InnerCollection = new ObservableCollection<string> { "Inner 1", "Inner 2", "Inner 3" };
				TestCommand = new SimpleCommand<object, object>(Test);
				NotifyPropertyChanged("OuterCollection");
				NotifyPropertyChanged("InnerCollection");
				NotifyPropertyChanged("TestCommand");
			}
			public void Test(object o)
			{
				var a = InnerListBoxSelectedItem;
				var b = OuterListBoxSelectedItem;
				"".ToString();
			}
		}
	}
