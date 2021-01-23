	public class Game1
	{
		private static int _someVariable = 15;
		public static int SomeVariable
		{
			get { return _someVariable; }
			set { _someVariable = value; }
		}
	}
	public class MainClass
	{
		public static void Main()
		{
			Console.WriteLine (Game1.SomeVariable);
			Game1.SomeVariable = 30;
			Console.WriteLine (Game1.SomeVariable);
		}
	}
}
