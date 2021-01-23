    private static DateTime TruncateDate(DateTime inDate, Accuracy accuracy){
			switch (accuracy)
			{
				case Accuracy.Year:
					return new DateTime(inDate.Year, 1, 1);
				case Accuracy.Quarter:
					int i = inDate.Month % 3;
					return new DateTime(inDate.Year, inDate.Month - i + 1, 1);
				case Accuracy.Month:
					return new DateTime(inDate.Year, inDate.Month, 1);
				case Accuracy.Week:
					return new DateTime(inDate.Year, inDate.Month, inDate.Day - DayOfWeekToInt(inDate.DayOfWeek));
				case Accuracy.Day:
					return new DateTime(inDate.Year, inDate.Month, inDate.Day);
				case Accuracy.Hour:
					return new DateTime(inDate.Year, inDate.Month, inDate.Day, inDate.Hour, 0, 0);
				case Accuracy.Minute:
					return new DateTime(inDate.Year, inDate.Month, inDate.Day, inDate.Hour, inDate.Minute, 0);
				case Accuracy.Second:
					return new DateTime(inDate.Year, inDate.Month, inDate.Day, inDate.Hour, inDate.Minute, inDate.Second);
				default:
					throw new ArgumentOutOfRangeException("accuracy");
			}
		}
	public enum Accuracy { Year, Quarter, Month, Week, Day, Hour, Minute, Second};
	private static int DayOfWeekToInt(DayOfWeek day) {
			
			switch (day)
			{ 
					
				case DayOfWeek.Sunday:
					return 0;
				case DayOfWeek.Monday:
					return 1;
				case DayOfWeek.Tuesday:
					return 2;
				case DayOfWeek.Wednesday:
					return 3;
				case DayOfWeek.Thursday:
					return 4;
				case DayOfWeek.Friday:
					return 5;
				case DayOfWeek.Saturday:
					return 6;
				default:
					throw new ArgumentOutOfRangeException("day");
			}
		}
