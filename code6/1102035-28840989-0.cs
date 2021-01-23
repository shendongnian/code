    Dictionary<string, string> mappings = new Dictionary<string, string>()
    {
        { "United States", "US" },
        { "United States of America", "US" },
        { "USA", "US" }
    };
    return ZipCodesAndCountryCodes
               .GroupJoin(mappings,
                          a => a.CountryCode,
                          b => b.Key,
                          (a, b) => new { 
                                            a.ZipCode,
                                            CountryCode = b.Value.FirstOrDefault() ?? a.CountryCode
                                        },
                          StringComparer.CurrentCultureIgnoreCase);
