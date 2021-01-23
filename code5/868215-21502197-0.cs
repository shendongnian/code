    string[] oku = File.ReadAllLines("test.prp");
    foreach(string sLine in oku)
    {
        string[] columns = sLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        // Check for columns here.
    }
      
