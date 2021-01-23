	class Program
	{
		static void Main(string[] args)
		{
            string entryString;
            decimal bidNum;
            const decimal MIN = 10.00m;
			
			Console.Write("Please enter a bid for the item:  ");
			entryString = Console.ReadLine().ToLower();
			decimal.TryParse(entryString, out bidNum);  // this turns it into a double...
			BidMethod(bidNum, MIN);
			Console.ReadLine();
		}
		
