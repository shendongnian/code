    string[] specials = new string[] { "special1", "special2", "special3" };
    for (int i = 0; i < specials.Length; i++)
    {
        string match = string.Format("(?<=\\s){0}(?=\\s)", specials[i]);
        if (Regex.IsMatch(name, match, RegexOptions.IgnoreCase))
        {
            name = Regex.Replace(name, match, specials[i], RegexOptions.IgnoreCase);
            break;
        }
    }
