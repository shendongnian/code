	public class Month : DependencyObject
	{
		public Month(int number, int count, ViewModel parent)
		{
			_parent = parent;
			Number = number;
			Days.Add(new Day { IsLastDayOfMonth = false, IsFirstDayOfMonth = true });
			for (int i = 0; i < count; i++)
			{
				Days.Add(new Day { 
					Number = i + 1, 
					IsLastDayOfMonth = false, 
					IsFirstDayOfMonth = false });
			}
			Days.Add(new Day { IsLastDayOfMonth = true, IsFirstDayOfMonth = false });
			SelectedDay = Days[1];//first is empty so by default day1 is selected
		}
		ViewModel _parent;
		//Number Dependency Property
		public int Number
		{
			get { return (int)GetValue(NumberProperty); }
			set { SetValue(NumberProperty, value); }
		}
		public static readonly DependencyProperty NumberProperty =
			DependencyProperty.Register("Number", typeof(int), typeof(Month), new UIPropertyMetadata(1));
		//Days Observable Collection
		private ObservableCollection<Day> _days = new ObservableCollection<Day>();
		public ObservableCollection<Day> Days { get { return _days; } }
		//SelectedDay Dependency Property
		public Day SelectedDay
		{
			get { return (Day)GetValue(SelectedDayProperty); }
			set { SetValue(SelectedDayProperty, value); }
		}
		public static readonly DependencyProperty SelectedDayProperty =
			DependencyProperty.Register("SelectedDay", typeof(Day), typeof(Month),
			new UIPropertyMetadata(null, (d, e) =>
			{
				var viewModel = ((Month)d)._parent;
				if (((Day)e.NewValue).IsLastDayOfMonth)
				{
					var selMonth = viewModel.Months.FirstOrDefault(x => x.Number == ((Month)d).Number + 1);
					if (selMonth == null || selMonth.Number == 1) return;
					viewModel.SelectedMonth = selMonth;
					viewModel.SelectedMonth.SelectedDay =
	 					viewModel.SelectedMonth.Days[1];//first real day of month
				}
				else if (((Day)e.NewValue).IsFirstDayOfMonth)
				{
					var selMonth = viewModel.Months.FirstOrDefault(x => x.Number == ((Month)d).Number - 1);
					if (selMonth == null) return;
					viewModel.SelectedMonth = selMonth;
					viewModel.SelectedMonth.SelectedDay = 
						viewModel.SelectedMonth.Days[
						viewModel.SelectedMonth.Days.Count - 2];//last real day of month
				}
			}));
	}
