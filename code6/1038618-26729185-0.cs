    public class DateComparer : IEqualityComparer<DateTime>
		{
				public bool Equals(DateTime x, DateTime y)
				{
						DateTime compareTime = new DateTime(y.Year, y.Month, y.Day, 7, 0, 0);
						return x < compareTime.AddDays(1) && x >= compareTime;
				}
				public int GetHashCode(DateTime dt)
				{
						// Normalise unique hashcode to single group time [before 7am uses the previous day]
						DateTime hashDt = new DateTime(dt.Year, dt.Month, dt.Day);
						if (dt.Hour < 7)
						{
								hashDt = hashDt.AddDays(-1);
						}
						return hashDt.GetHashCode();
				}
		}
