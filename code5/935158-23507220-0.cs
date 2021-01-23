		static void Main(string[] args)
		{
			DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
			DateTime sunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
			DateTime firstDay = sunday.AddDays((int)firstDayOfWeek);
			DateTime value = firstDay;
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(value.ToShortDateString());
				value = value.AddDays(14);
			}
		}
