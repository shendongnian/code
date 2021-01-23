    string input = "When this Pokémon has 1/3 or less of its [HP]{mechanic:hp} remaining, its []{type:grass}-type moves inflict 1.5× as much [regular damage]{mechanic:regular-damage}.";
    //Note: Changed pattern to only have 2 match groups to simplify the replace
    string pattern = @"\[([\s\w'-]*)\]\{([\s\w'-]*:[\s\w'-]*)\}";
    MatchCollection matches = Regex.Matches(input, pattern);
    for(int i = 0; i < matches.Count; i++)
    {
        string spanText = matches[i].Groups[1].ToString();
        string spanClass = matches[i].Groups[2].ToString();
        input = input.Replace(matches[i].Groups[0].ToString(), "<span class=\"" + spanClass + "\">" + spanText + "</span>");
    }
    Console.WriteLine(input);
