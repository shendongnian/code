    CultureInfo provider = CultureInfo.InvariantCulture;
    string s = "X23_CBW_13CP05AUGR1_20130901000000";
    Regex rg = new Regex(@"\d{8}");
    Match m = rg.Match(s);
    if (m.Success)
    {
        DateTime d = DateTime.ParseExact(m.Captures[0].Value, "yyyyMMdd", provider);
        // ... 
        // Do something with your value here
    }
