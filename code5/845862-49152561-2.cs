    class YourViewModel : IFilterCollectionViewSource
	{
	    public event EventHandler FilterRefresh;
		private string _SearchTerm = string.Empty;
		public string SearchTerm
		{
			get { return _SearchTerm; }
			set {
				SetProperty(ref _SearchTerm, value);
	            FilterRefresh?.Invoke(this, null);
			}
		}
		private ObservableCollection<YourItemType> _YourCollection = new ObservableCollection<YourItemType>();
		public ObservableCollection<YourItemType> YourCollection
		{
			get { return _YourCollection; }
			set { SetProperty(ref _YourCollection, value); }
		}
	    public void Filter(object sender, FilterEventArgs e)
	    {
	        e.Accepted = (e.Item as YourItemType)?.YourProperty?.ToLower().Contains(SearchTerm.ToLower()) ?? true;
	    }
	}
