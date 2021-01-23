	public interface ITest
	{
		bool IsTrue(int i);
	}
	public static TestClass
	{
		public static void Main()
		{
			var isAny = It.IsAny<int>();
			var tester = new Mock<ITest>();
			tester.Setup(t => t.IsTrue(isAny)).Returns(true);
			Console.WriteLine(tester.Object.IsTrue(1));     //false
			Console.WriteLine(tester.Object.IsTrue(isAny)); //true
		}
	}
