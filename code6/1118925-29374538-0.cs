    public static void Main()
    {
    	List<string> stringList = new List<string>();
    	stringList.Add("Hello");
    	stringList.Add("world");
    	var strOut = string.Join(" ",stringList.ToArray());
    	Console.WriteLine(strOut);
    }
