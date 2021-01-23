        string userValue = Console.ReadLine();
        do
        {
            foreach (string cue in eliza.Keys)
                if (userValue.IndexOf(cue) >= 0)
                { Console.WriteLine(eliza[cue]); break; }
            userValue = Console.ReadLine().ToLower();
        }
        while (userValue != "" && userValue.IndexOf("bye") < 0);
