    var dtfi = CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat;
    foreach (string pattern in dtfi.GetAllDateTimePatterns())
    {
        Debug.WriteLine(pattern);
    }
