    public class ExtraStringDataPoint : IDataPoint
	{
		public ExtraStringDataPoint(double x, double y , string s)
		{
			X = x;
			Y = y;
			Extra = s;
		}
		public double X { get; set; }
		public double Y { get; set; }
		public string  Extra { get; set; }
	}
