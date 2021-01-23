		public static DateTime AddBusinessDays(this DateTime source, int daysToAdd, params DayOfWeek[] workdays)
		{
			if (daysToAdd <= 0)
				return source;
			var current = source;
			while (daysToAdd > 0)
			{
				current = current.AddDays(1);
				if (workdays.Contains(current.DayOfWeek))
					daysToAdd--;
			}
			return current;
		}
