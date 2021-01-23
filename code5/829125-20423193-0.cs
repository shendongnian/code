    String subjectString = "Hello I'm 43 years old, I need 2 burgers each for 1.99$";
    var matches = Regex.Matches(subjectString, @"\d+(\.\d+)?");
    for (int i = 0; i < matches.Count; i++ )
    {
        double d = double.Parse(matches[i].Value);
    }
