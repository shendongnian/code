    List<string> listLines = new List<string>();
    foreach (var line in File.ReadLines("C:\\Data.txt"))
    {
    	var str = line.Split(new char[] { '=', '$'},
                                             StringSplitOptions.RemoveEmptyEntries);
    	listLines.Add(str[1].Trim());
    }
