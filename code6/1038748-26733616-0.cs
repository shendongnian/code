    class Program
    {
        static void Main()
        {
	    Regex regex = new Regex(@"\b\d+\b(?=[^\d]*$)");
	    Match match = regex.Match("/forum/thread-93912/34");
	    if (match.Success)
	    {
	        Console.WriteLine(match.Value);
	    }
        }
    }
