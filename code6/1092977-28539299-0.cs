    class Program
	{
		static void Main(string[] args)
		{
			myclass obj = new myclass();
			obj.b = true;
			while (obj.notEnough())
			{
				Thread.Sleep(5);
			}
		}
	}
	public class myclass
	{
		public bool b;
		public bool notEnough()
		{
			if (this.b)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
