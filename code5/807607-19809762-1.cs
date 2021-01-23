	public class Month : DependencyObject
	{
		public Month(int number, int count, ViewModel parent)
		{
			_parent = parent;
			Number = number;
			for (int i = 0; i < count; i++)
			{
				Days.Add(new Day { Number = i + 1, IsLastDayOfMonth = false });
			}
			Days.Add(new Day { IsLastDayOfMonth = true });
			SelectedDay = Days.First();
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
					viewModel.SelectedMonth = new Month(viewModel.SelectedMonth.Number+1, 31, viewModel);//this is simplified
			}));
	}
