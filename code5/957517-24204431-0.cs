        string word = "LANE";
        string[] wordList = { "CLEAN", "AGED", "CAGED", "RAGE" };
        foreach (string w in wordList)
        {
            Boolean x = true;
            foreach (char c in word)
            {
                if (!w.Contains(c))
                {
                    x = false;
                    break;
                }
            }
            if (x)
                Console.WriteLine(w);
