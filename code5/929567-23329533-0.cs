    string myString = "<tr class=\"discussion r0\"><td class=\"topic starter\"><a href=\"SITE?d=6638\">Test di matematica</a></td>";
    Regex rx = new Regex(@"<a.*?>(.*?)</a>");
    MatchCollection matches = rx.Matches(myString);
    if (matches.Count > 0)
    {
        Match match = matches[0]; // only one match in this case
        GroupCollection groupCollection = match.Groups;
        Console.WriteLine( groupCollection[1].ToString());
    }
