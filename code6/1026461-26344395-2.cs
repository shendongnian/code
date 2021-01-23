	class Program
	{
		static void Main(string[] args)
		{
			DbGeometry test = DbGeometry.FromText("POLYGON((1 1, 1 2, 3 3, 1 1))");
			var foo = test.AsText();
			var points = new List<Point>();
			Console.WriteLine(foo);
			if (foo.StartsWith("POLYGON ((")
				&& foo.EndsWith("))"))
			{
				foo = foo.Substring(10, foo.Length - 12);
				var rawPoints = foo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
				foreach (var rawPoint in rawPoints)
				{
					var splitPoint = rawPoint.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					points.Add(new Point() { X = decimal.Parse(splitPoint[1]), Y = decimal.Parse(splitPoint[0]) });
				}
			}
			foreach (var point in points)
			{
				Console.WriteLine(point.ToString());
			}
			Console.ReadKey();
		}
	}
	class Point
	{
		public decimal X { get; set; }
		public decimal Y { get; set; }
		public override string ToString()
		{
			return string.Format("[X={0}],[Y={1}]", X, Y);
		}
	}
