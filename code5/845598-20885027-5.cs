    public class MainViewModel : Conductor<IMainScreenTabItem>.Collection.OneActive
	{
		public MainViewModel(IEnumerable<IMainScreenTabItem> tabs)
		{
			Items.AddRange(tabs);
		}
	}
