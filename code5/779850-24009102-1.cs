    StreamReader myReader = new StreamReader(Path)
    String line = “ “;
    for (int i =0; i <15; i++)
    {
        line = myReader.ReadLine();
        char[] delimiters = new char[] {' ', '\t'};
        string[] columnValues = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    }  
