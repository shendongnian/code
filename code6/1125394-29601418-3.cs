    int newLineIndex = 100;
    string newLineText = "Here's the new line";
    using (var writer = new StreamWriter(outputFileName))
    {
        int lineNumber = 0;
        foreach (var line in File.ReadLines(inputFileName))
        {
            if (lineNumber == newLineIndex)
            {
                writer.WriteLine(newLineText);
            }
            else if (lineNumber > 0)
            {
                writer.WriteLine();
            }
            writer.Write(line);
            
            lineNumber++;
        }
    }
