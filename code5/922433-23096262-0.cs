    public static void Main()
	{
		string[] paths = new[] { "/a/b", "/a/bb", "/a/bbb", "/b/a", "/b/aa", "/b/aaa", "/c/d", "/d/e" }; 
		string root = "/";
		
		Console.WriteLine(string.Join(", ", paths.Select(s => GetSubdirectory(root, s)).Where(s => s != null).Distinct()));
	}
	
	static string GetSubdirectory(string root, string path)
    {
		string subDirectory = null;
        int index = path.IndexOf(root);
		
		Console.WriteLine(index);
        if (root != path && index == 0)
		{
            subDirectory = path.Substring(root.Length, path.Length - root.Length).Trim('/').Split('/')[0];
		}
		
        return subDirectory;
    }
