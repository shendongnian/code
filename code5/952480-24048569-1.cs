    public bool isCorrectGram(List<string> rules)
    {
        Regex rgx = new Regex("^[a-z][A-Z]?$");
        foreach(string line in rules)
        {
            // The compiler can infer the generic type (<string>) for `ToList()`.
            List<string> temp = line.Split('|', '→').ToList();
            foreach (string rule in temp)
            {
                if (rule != temp[0] && !rgx.IsMatch(rule))
                {
                    return false;
                }
            }
        }
        return true;
    }
