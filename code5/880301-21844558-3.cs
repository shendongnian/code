	class ExtremetiesDeterminer
	{
		private IEnumerable<Point> endpoints;
		public Line DetermineBoundaries(IEnumerable<Line> complicatedShapeLines)
		{
			endpoints = complicatedShapeLines.SelectMany(line => line.Endpoints);
			return new Line
			{
				Start = FindExtremety(Enumerable.Min),
				End = FindExtremety(Enumerable.Max)
			};
		}
		private Point FindExtremety(
			SingleAxisExtremetyDeterminer findSingleAxisExtremety)
		{
			return new Point
			{
				X = findSingleAxisExtremety(endpoints, point => point.X),
				Y = findSingleAxisExtremety(endpoints, point => point.Y)
			};
		}
		public delegate int SingleAxisExtremetyDeterminer(
			IEnumerable<Point> points, Func<Point, int> getCoordinate);
	}
