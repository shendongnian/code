	Dictionary<string, string> words = new Dictionary<string, string>();
	Console.WriteLine("Enter the number of words you wish to use");
	int wordsNumber = int.Parse(Console.ReadLine());
	for (int i = 0; i < wordsNumber; i++)
	{
		Console.WriteLine("Enter word in Hebrew.");
		string hebrew = Console.ReadLine();
		Console.WriteLine("Now enter the translate of {0} in English.", hebrew);
		string english = Console.ReadLine();
		words.Add(hebrew, english);
	}
	Console.WriteLine("Now enter the sentence that you want to translate..and press ENTER");
	string searchSentence = Console.ReadLine();
	string[] splitSentence = searchSentence.Split(new char[]{' '});
	string result = "";
	foreach (string s in splitSentence)
		result += string.Format("{0} ", words[s]);
	Console.WriteLine(result);
	Console.ReadLine();
