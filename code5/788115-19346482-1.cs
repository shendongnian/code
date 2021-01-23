    static void Main(string[] args)
    {
    	Random Rnd = new Random();
    	List<int> IntList = new List<int>();
    	int NumberOfInts = 10, MinValue = 19, MaxValue 21;
    	
    	for (int i = 0; i < NumberOfInts; i++) { IntList.Add(Rnd.Next(1, 10));
    	for (int i = 0; i < NumberOfInts; i++) { Console.Write(IntList[i] + " "); } Console.WriteLine(); Console.WriteLine();
    	
    	GenerateLimitedCombinations(IntList, MinValue, MaxValue);
    	Console.ReadKey();
    }
