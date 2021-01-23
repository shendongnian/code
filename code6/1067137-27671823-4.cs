    var patterns = new[] { "dog", "dog has" };
    var sb = new StringBuilder();
    for (var i = 0; i < patterns.Length; i++)
        sb.Append(@"(?=(?<p").Append(i).Append(">").Append(patterns[i]).Append("))?");
    var regex = new Regex(sb.ToString(), RegexOptions.Compiled);
    Console.WriteLine("Pattern: {0}", regex);
    var input = "a dog has been seen with another dog";
    Console.WriteLine("Input: {0}", input);
    foreach (var match in regex.Matches(input).Cast<Match>())
    {
        for (var i = 0; i < patterns.Length; i++)
        {
            var group = match.Groups["p" + i];
            if (!group.Success)
                continue;
            Console.WriteLine("Matched pattern #{0}: '{1}' at index {2}", i, group.Value, group.Index);
        }
    }
