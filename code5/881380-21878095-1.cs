    var input = "1 . 2 To Other Mobiles asdf asd fas df asd fas dfas df asd fas df sdaf Total asdfasdfasdfasdfasdfasdf another Total ertyertyertyerty eryertwer";
                
    var sub1 = "1 . 2 To Other Mobiles";
    var sub2 = "Total";
    
    // note the capture group is missing the ?    
    var match = Regex.Match(input, sub1 + "(.*)" + sub2, RegexOptions.IgnoreCase);
    if (match.Success)
    {
       var m = match.Groups[1].Value;
        Console.WriteLine(sub1 + m);
    }
