	public class ViewModel : DependencyObject
	{
		public ViewModel()
		{
			for (int i = 0; i < 12; i++)
			{
				Months.Add(new Month(i+1, 31, this));//this is simplified
			}
			SelectedMonth = Months.First();
		}
		//Months Observable Collection
		private ObservableCollection<Month> _months = new ObservableCollection<Month>();
		public ObservableCollection<Month> Months { get { return _months; } }
		//SelectedMonth Dependency Property
		public Month SelectedMonth
		{
			get { return (Month)GetValue(SelectedMonthProperty); }
			set { SetValue(SelectedMonthProperty, value); }
		}
		public static readonly DependencyProperty SelectedMonthProperty =
			DependencyProperty.Register("SelectedMonth", typeof(Month), typeof(ViewModel), new UIPropertyMetadata(null));
	}
