    string outputFileName = "temp.txt";
    using (var outputFile = new StreamWriter(outputFileName))
    {
        foreach (var line in File.ReadLines(inputFileName))
        {
            var newLine = line.Substring(0, 124) + "************" +
                        line.Substring(136, lineOfText.Length - 136);
            outputFile.WriteLine(newLine);
        }
    }
