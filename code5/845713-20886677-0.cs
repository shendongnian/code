	public class HourListComparer : IEqualityComparer<Hour>
	{
		public bool Equals(Hour x, Hour y)
		{
			return x != null && y != null && x.OperatingHourID == y.OperatingHourID;
		}
		public int GetHashCode(Hour obj)
		{
			return obj.OperatingHourID.GetHashCode();
		}
	}
