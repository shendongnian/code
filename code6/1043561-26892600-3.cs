    var n = 5365.20M;
    var s1 = n.ToString("C", new CultureInfo("en-US"));
    var s2 = s1.Replace("US", "");
    
    // The currency symbol being used.  In your case it's US$, in my case it's $
    Console.WriteLine(new CultureInfo("en-US").NumberFormat.CurrencySymbol);
    // The original output
    Console.WriteLine(s1);
    // The corrected output
    Console.WriteLine(s2);
