    string s = "X23_CBW_13CP05AUGR1_20130901000000";
    Regex rg = new Regex(@"\d{8}");
    Match m = rg.Match(s);
    if (m.Success)
    {
        DateTime d = DateTime.ParseExact(m.Value, "yyyyMMdd",
                          CultureInfo.InvariantCulture);
        // ... 
        // Do something with your value here
    }
