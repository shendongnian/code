    string CurrentLine; 
    int LastLineNumber;   
    void NextLine() 
    {
        // using will make sure the file is closed
        using(System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt"))
        {
            // Skip lines
            for (int i=0;i<LastLineNumber;++i)
                file.ReadLine();
            // Store your line
            CurrentLine = file.ReadLine();
            LastLineNumber++;
        }
    }
