	internal interface ICanvas
	{
		void Draw();
	}
	public class Canvas : ICanvas
	{
		private readonly IRenderer _renderer;
		private readonly List<Circle> _circles = new List<Circle>();
		private readonly List<Square> _squares = new List<Square>();
		public Canvas(IRenderer renderer)
		{
			_renderer = renderer;
		}
		public void Draw()
		{
			foreach (var circle in _circles)
			{
				_renderer.Draw(circle);
			}
			foreach (var square in _squares)
			{
				_renderer.Draw(square);
			}
		}
	}
