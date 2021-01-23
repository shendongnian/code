    //using System.Text.RegularExpressions;
    //the keyword you're looking for
    String keyword = "Accumulated Earnings Tax";
    //opening the file
    using (StreamReader stream = File.OpenText("yourfile.txt"))
    {
        //grabbing the whole content of the file at once
        String content = stream.ReadToEnd();                               
        //the regular expression, also see the regex101-link
        Regex re = new Regex("(" + keyword + "\\.).+?\n(.*\\.)");
        Match match = re.Match(content);
        if (match.Success)
        {
            //if the expression matches we can access our capturing groups
            //and extract the keyword and description
            Console.WriteLine("Keyword: " + match.Groups[1]);
            Console.WriteLine("Description: " + match.Groups[2]);
        }
    }
