	private static string SpecialReplace(string text)
	{
		var result = text.Replace(',', '.');
		return result;
	}
    public static void Main()
    {
	    string text = "version=\"1,0,0\"";
	    var regex = new Regex(@"version=""[\d,]*""");
	    var result = regex.Replace(text, x => SpecialReplace(x.Value));
	    Console.WriteLine(result);
    }
