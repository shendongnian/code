    string[] fileLines = System.IO.File.ReadAllLines(@"input_5_5.txt", Encoding.GetEncoding(1250));
    for(int line = 0; line < fileLines.Length; line++)
    {
        string[] splittedLines = fileLines[line].Trim().Split(' ');
        for(int col = 1; col < splittedLines.Length; col++)
        {
            // do whatever you want here
        }
    }
