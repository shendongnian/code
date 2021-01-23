	class ExtremetiesDeterminer
	{
		private IEnumerable<Point> endpoints;
		public Box DetermineBoundaries(IEnumerable<Line> complicatedShapeLines)
		{
			endpoints = complicatedShapeLines.SelectMany(line => line.Endpoints);
			return new Box
			{
				Corner = FindExtremety(Enumerable.Min),
				OppositeCorner = FindExtremety(Enumerable.Max)
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
