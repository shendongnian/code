    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;            
    var text = "c";
    var myStrings = new List<string>() { "Aa", "ACB", "cc" };
    var regEx = new System.Text.RegularExpressions.Regex(text, options);
    var results = myStrings
                 .Where<string>(item => regEx.IsMatch(item))
                 .ToList<string>();
 
    //you will have 2 items in results
    foreach(string s in results)
    {
        GetItems(s);
    }
