    using (var sr = new StringReader(fileContents))
    {
        using (var outputWriter = new StreamWriter(@"C:\temp\output.txt"))
        {
            char[] buffer = new char[10];
            int numChars;
            while ((numChars = sr.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                outputWriter.Write(buffer, 0, numChars);
            }
        }
    }
