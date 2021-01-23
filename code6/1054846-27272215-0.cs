    protected void Page_Load(object sender, EventArgs e)
    {
    	string[] lines = { "This is line 1", "This is line 2", "This is line 3", "This is line 4" };
    	
    	Console.WriteLine(FormatLines(lines));
    }
    
    public string FormatLines(string[] lines)
    {
    	string putTogetherQuery = "";
    
    	for (int i = 0; i < lines.Length; i++)
    		putTogetherQuery += "{" + i + "}\n ";
    
    	return String.Format(putTogetherQuery, lines);
    }
