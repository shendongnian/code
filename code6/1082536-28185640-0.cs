	namespace ShapeTest
	{
		[TestClass]
		public class CircleTest
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void RadiusIsGreaterThanZero()
			{
			   Circle c = new Circle(0);
			}
		}
	}
