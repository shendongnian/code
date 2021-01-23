	using System.Linq; //You need add reference to namespace
	static void Main()
	{
		string numbersStr = Console.ReadLine();
		int[] numbersArrary = numbersStr.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
	}
