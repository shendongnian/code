	public abstract class IColor 
	{
		// override in every class
		public abstract void PrintColor();
		// has the correct type passed with the interface
		public void CatchColor(IColor c)
		{
			c.PrintColor();
		}
	}
