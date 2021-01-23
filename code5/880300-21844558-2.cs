	class Point
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
	class Line
	{
		public Point Start { get; set; }
		public Point End { get; set; }
		public IEnumerable<Point> Endpoints
		{
			get
			{
				return new[] { Start, End };
			}
		}
	}
