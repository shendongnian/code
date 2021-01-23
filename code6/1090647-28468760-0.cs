        string line;
        List<string> tokenList = new List<string>();
        char[] aa = new char[] { ' ', '\t', '\r', '\n' };
        do
        {
            line = sr.ReadLine();
            if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
            {
                foreach (var test in line.Split(aa, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (test != null)
                    {
                        //System.Console.WriteLine(test);
                        tokenList.Add(test);
                    }
                }
            }
        } while (sr.EndOfStream != true);
        foreach (var toke in tokenList)
        {
            System.Console.WriteLine(toke);
        }
