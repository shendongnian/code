    StreamReader sr = new StreamReader("file1.txt");
    
    while ( !sr.EndOfStream )
    {
        string line = sr.ReadLine();
    
        string[] parts = line.Split(' ');
        string command = parts[0].Trim();
    
        //Use parts[x] where x > 0 to extract other items of the line
    }
