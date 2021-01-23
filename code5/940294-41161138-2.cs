	public interface IRenderer
	{
		void Draw(IShape shape);
	}
	public interface IShape
	{
		void Draw(IRenderer renderer);
	}
	public class Dx11Renderer : IRenderer
	{
		public void Draw(IShape shape)
		{
			shape.Draw(this);
		}
	}
	public class GlRenderer : IRenderer
	{
		public void Draw(IShape shape)
		{
			shape.Draw(this);
		}
	}
	public class Circle : IShape
	{
		public void Draw(IRenderer renderer)
		{
			if (renderer.GetType() == typeof(Dx11Renderer))
			{
				Console.WriteLine("Draw circle with DX11");
			}
			if (renderer.GetType() == typeof(GlRenderer))
			{
				Console.WriteLine("Draw circle with GL");
			}
		}
	}
	public class Square : IShape
	{
		public void Draw(IRenderer renderer)
		{
			if (renderer.GetType() == typeof(Dx11Renderer))
			{
				Console.WriteLine("Draw square with DX11");
			}
			if (renderer.GetType() == typeof(GlRenderer))
			{
				Console.WriteLine("Draw square with GL");
			}
		}
	}
