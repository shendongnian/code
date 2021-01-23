    var subject = "H12345678ABC";
    var regex = new Regex(@"(?((?<hgroup>H))\k<hgroup>.{8}|.{10})(?<user>.*)");
    var match =regex.Match(subject);
    if(match.Success)
    {
    	Console.WriteLine(match.Groups["user"].Value);//prints ABC
    }
    else
    {
    	Console.WriteLine("No Match");
    }
