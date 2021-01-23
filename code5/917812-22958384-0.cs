     static void Main()
    {
    	var lines = System.IO.File.ReadAllLines(@"c:\temp\log.txt");
    	Parallel.ForEach(lines,line => processLine(line));
    }
    
    private static void processLine(string line)
    {
    	Console.WriteLine(line);
    }
