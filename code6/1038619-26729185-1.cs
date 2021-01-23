    public class DateComparer : IEqualityComparer<DateTime>
		{
				public bool Equals(DateTime x, DateTime y)
				{
						return GetHashCode(x) == GetHashCode(y);
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
