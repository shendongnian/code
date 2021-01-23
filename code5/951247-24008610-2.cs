	public string SearchText(string s)
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        foreach (string line in lines)
        {
            if(line.Contains(s)){
                var l = line.Split(',');
                return l[1];
            }
        }
        return "";
    }
