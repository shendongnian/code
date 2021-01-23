        string s2 = "Have a very good day, Joe";
        IEnumerable<string> diff;
        MatchCollection matches = Regex.Matches(s1, @"\b[\w']*\b");
        IEnumerable<string> first= from m in matches.Cast<Match>()
                    where !string.IsNullOrEmpty(m.Value)
                    select TrimSuffix(m.Value);
        MatchCollection matches1 = Regex.Matches(s2, @"\b[\w']*\b");
        IEnumerable<string> second = from m in matches1.Cast<Match>()
                                     where !string.IsNullOrEmpty(m.Value)
                                     select TrimSuffix(m.Value);
     
        if (second.Count() > first.Count())
        {
            diff = second.Except(first).ToList();
        }
        else
        {
            diff = first.Except(second).ToList();
        }
        }
       static string TrimSuffix(string word)
       {
        int apostropheLocation = word.IndexOf('\'');
        if (apostropheLocation != -1)
        {
            word = word.Substring(0, apostropheLocation);
        }
        return word;
       }
 
