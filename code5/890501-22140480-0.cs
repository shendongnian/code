    string tempFile = "text2.txt";
    List<string> linesWithREL = new List<string>();
    using (var sr = new StreamReader("file.txt"))
    using (var sw = new StreamWriter(tempFile))
    {
        string line;
    
        while ((line = sr.ReadLine()) != null)
        {
            //check if the current line should be copied
            if (line.Contains("whatever"))
            {
                   linesWithREL.Add(line.Substring(0,4));
                   sw.WriteLine(line);
            }
        }
    }
