    Regex regex = new Regex(@"(?<LineNumber>\d+)[:](?<Code>.+)$");
            
    using (StreamReader reader = new StreamReader("TextFile1.txt"))
    {
        string s = null;
                
        while ((s = reader.ReadLine()) != null)
        {
            Match match = regex.Match(s);
            if (match.Success)
            {
                Console.WriteLine("{0}: {1}", match.Groups["LineNumber"].Value,
                    match.Groups["Code"].Value);
            }
        }
    }
