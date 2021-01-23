	using System.Linq; //You need add reference to namespace
	static void Main()
	{
		string numbersStr = "1 1 3 1 2 2 0 0";
		int[] numbersArrary = numbersStr.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
	}
