    void Main()
    {
    	var str = string.Format("{0:X}", 12345678);
    	var splits = Split(str, 2);
    	var rejoinedSplits = string.Join("-",splits);
    	Console.WriteLine (rejoinedSplits); //tested in linqpad, gave me BC-61-4E
    }
    static IEnumerable<string> Split(string str, int chunkSize)
    {
    	  return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
    }
