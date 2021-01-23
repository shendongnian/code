	private static List<string> ReadFile(string FileName, char[] seps)
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine("File not found");
            return null;
        }
        using (StreamReader sr = new StreamReader(FileName, Encoding.Default))
        {
            string content = sr.ReadToEnd();
            return content.Split(seps, StringSplitOptions.RemoveEmptyEntries).Where (c => c.Length > 1).ToList();
        }
    }
	
