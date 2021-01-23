    var date = Regex.Match(input, @"(\d{4}/\d{2}/\d{2} \d{2}:\d{2}:\d{2})").Groups[0].Value;
    var secondLine = Regex.Match(input, @"\\@(.*)").Groups[1].Value;
    var theRest = Regex.Matches(input, @"(?:\()([^)]+)(?:\))");
    Console.WriteLine(date); // 2008/12/22 08:10:02
    Console.WriteLine(secondLine); // DC331TMMBA5BAC
    foreach (Match match in theRest) {
        Console.WriteLine(match.Groups[1].Value);
    }
