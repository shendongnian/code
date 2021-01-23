	class Program
	{
		static void Main(string[] args)
		{
			var objectA = new Test();
			objectA.PropA = 1;
			objectA.PropB = 10;
			var objectB = new Test() { PropA = 2, PropB = 20 };
		}
	}
	public class Test
	{
		public int PropA { get; set; }
		public int PropB { get; set; }
	}
