	namespace Crossword
	{
		class Program
		{
			static void Main(string[] args)
			{
					ArrayList array = DataFileReader.DataFile(args[0]);
					String characters = args[0];
					ArrayList wordLength = WordLength(characters,array); // this will pass the variables to your method
			}
			public static ArrayList WordLength(String characters, ArrayList array)
			{
				ArrayList wordLength = new ArrayList();
				foreach (string line in array)
					if (line.Length == characters.Length){
						wordLength.Add(line);
						Console.WriteLine(line);
			  }
				return wordLength;
			}
	}
