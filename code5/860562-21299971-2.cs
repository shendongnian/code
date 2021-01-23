    string s = "X23CBW13992238455222348CP05AUGR120130901000000";
    Regex rg = new Regex(@"\d{8,}");
    MatchCollection mc = rg.Matches(s);
    
    DateTime? d = null;
    
    
    foreach (Match m in mc)
    {
        string digits = m.Value;
    
        for (int n = 0; n < digits.Length - 8; n++)
        {
            try
            {
                d = DateTime.ParseExact(digits.Substring(n, 8), "yyyyMMdd",
                    CultureInfo.InvariantCulture);
    	        break;
            }
            catch
            { }
        }
    
        if (d != null)
            break;
    }
    
    
    if (d != null)
    {
    // Use your value here
    }
