	using MyGeometry.Abstract;
	using MyGeometry.Interface;
	namespace MyGeometry.RealShapes
	{
		public class Circle : Shape, IFlatShape
		{
			public Circle(int radius)
			{
				if(radius > 0)
					Length = radius;
				else
					throw new ArgumentOutOfRangeException("Radius must be greater than zero");
			}
			
			......
		}
	}
