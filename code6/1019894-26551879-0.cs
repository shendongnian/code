    private static void OnDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        CalendarEntryHorizontal elem = d as CalendarEntryHorizontal;
		if (elem != null)
		{
			elem.shrinkStoryboard.Completed += (o, ev) =>
			{
				DateTime date = (DateTime)e.NewValue;
				string month = date.ToString("MMMM").Substring(0, 3);
				string day = date.Day.ToString("D2");
				string year = date.Year.ToString("D4");
                // ...
				elem.growStoryboard.Begin();
			};
			elem.shrinkStoryboard.Begin();
		}
    }
