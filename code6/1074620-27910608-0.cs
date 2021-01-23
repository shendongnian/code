    string input = "Enter Type:=select top 10 type from cable}";
    System.Text.RegularExpressions.Regex regExPattern = new System.Text.RegularExpressions.Regex("(.*):=select.*}");
    System.Text.RegularExpressions.Match match = regExPattern.Match(input);
    string output = String.Empty;
    if( match.Success)
    {
        output = match.Groups[1].Value;
    }
    Console.WriteLine("Output = " + output);
