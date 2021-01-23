    s = "... wikipedia string ...";
    // define n, you probably have a dynamic n or one that's defined elsewhere...
    n=2;
    // split the string only n times
    string[] parts = s.Split(new string[] {"@##@"}, n, StringSplitOptions.None);
    // show splits (use them however you want)
    System.Show(parts);
