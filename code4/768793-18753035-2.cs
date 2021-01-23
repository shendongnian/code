    var providerMap = (new[] {
        new { Pattern = "SWGAS.COM"       , Name = "Southwest Gas" },
        new { Pattern = "georgiapower.com", Name = "Georgia Power" },
        // More specific first
        new { Pattern = "City of Austin"  , Name = "City of Austin" },   
        // Then more general
        new { Pattern = "Austin"          , Name = "Austin Electric Company" }   
        // And for everything else:
        new { Pattern = String.Empty      , Name = "Unknown" }
    }).ToList();
    txtVar.Provider = providerMap.First(p => txtVar.BillText.IndexOf(p.Pattern) > -1).Name; 
