	class DrawingDataNameComparer : IEqualityComparer<DrawingData>
	{
	
	    public bool Equals(DrawingData d1, DrawingData d2)
	    {
	        return d1.DrawingName.Equals(d2.DrawingName);
	    }
	
	
	    public int GetHashCode(DrawingData d)
	    {
	        return d.DrawingName.GetHashCode();
	    }
	
	}
	
	public class Test
	{
		public static void Main()
		{
			var distinct = _DrawingList.Distinct(new DrawingDataNameComparer ());
			var organized = distinct
				.OrderBy(c => c.DrawingName)
				.Concat(_DrawingList.Except(distinct).OrderBy(c => c.DrawingName));
		}
	}
