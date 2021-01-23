    class Program
        {
            static void Main()
            {
        	string[] pages = new string[]
        	{
        	    "cat.aspx",
        	    "really-long-page.aspx",
        	    "test.aspx",
        	    "invalid-page",
        	    "something-else.aspx",
        	    "Content/Rat.aspx",
        	    "http://dotnetperls.com/Cat/Mouse.aspx",
        	    "C:\\Windows\\File.txt",
        	    "C:\\Word-2007.docx"
        	};
        	foreach (string page in pages)
        	{
        	    string name = Path.GetFileName(page);
        	    string nameKey = Path.GetFileNameWithoutExtension(page);
        	    string directory = Path.GetDirectoryName(page);
        	    //
        	    // Display the Path strings we extracted.
        	    //
        	    Console.WriteLine("{0}, {1}, {2}, {3}",
        		page, name, nameKey, directory);
        	}
            }
        }
