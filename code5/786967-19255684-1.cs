    string[] possibleFormats = new[] { "yyyyMMdd", "yyyyMM'..'" };
                                                          ↑↑↑↑
    DateTime result;
    if (DateTime.TryParseExact("201310..", possibleFormats, null, 0, out result))
    {
        // result == {01/10/2013 00:00:00}
    }
