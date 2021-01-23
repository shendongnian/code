	public class CustomRect
	{
		private Rect rect;
		
		public CustomRect() : this(new Size(0.0, 0.0))
		{
		}
		
		public CustomRect(Size size)
		{
			rect = new Rect(size);
		}
		
		public Double Width
		{
			get { return rect.Width; }
			set { rect.Width = value; }
		}
		
		public Double X
		{
			get { return rect.X; }
			set { rect.X = value; }
		}
		
		public Double Y
		{
			get { return rect.Y; }
			set { rect.Y = value; }
		}
		
		public Double Height
		{
			get { return rect.Height; }
			set { rect.Height = value; }
		}
		
		public String ToString()
		{
			return String.Format("{0};{1};{2};{3}", Math.Round(rect.X, 2), Math.Round(rect.Y, 2), Math.Round(rect.Width, 2), Math.Round(rect.Height));
		}
	}
