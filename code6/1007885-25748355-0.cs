        string text = "aldkjf;la(100,200)a;slknl;knw(400,400)";
        string pattern = @"\(\d+,\d+\)";
        var matches = Regex.Matches(text, pattern);
        foreach(Match match in matches)
        {
            var numberMatches = Regex.Matches(match.Value, @"\d+");
            double x = double.Parse(numberMatches[0].Value);
            double y = double.Parse(numberMatches[1].Value);
            Console.WriteLine("{0}, {1}", x, y);
        }
