    string input = "When this Pokémon has 1/3 or less of its [HP]{mechanic:hp} remaining, its []{type:grass}-type moves inflict 1.5× as much [regular damage]{mechanic:regular-damage}.";
    string pattern = @"\[([\s\w'-]*)\]\{([\s\w'-]*):([\s\w'-]*)\}";
    MatchCollection matches = Regex.Matches(input, pattern);
    for(int i = 0; i < matches.Count; i++)
    {
        input = input.Replace(matches[i].Groups[0].ToString(), "{" + i + "}");
    }
    Console.WriteLine(input);
