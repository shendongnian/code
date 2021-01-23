    static string[] GetFiles(string directory, params string[] extensions)
    {
    	var allowed = new HashSet<string>(extensions, StringComparer.CurrentCultureIgnoreCase);
    
    	return Directory.GetFiles(directory)
    					.Where(f => allowed.Contains(Path.GetExtension(f)))
    					.ToArray();
    }
    
    static void Main(string[] args)
    {
    	string[] files = GetFiles(@"D:\My Documents", ".TXT", ".docx");
    	foreach(var file in files)
    	{
    		Console.WriteLine(file);
    	}
    }
