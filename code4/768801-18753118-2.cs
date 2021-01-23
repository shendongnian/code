    var mapping = new Dictionary<string, string>()
                            {
                                { "SWGAS.COM", "Southwest Gas" },
                                { "georgiapower.com", "Georgia Power" }
                                .
                                .
                            };
    return mapping.Where(pair => txtvar.BillText.IndexOf(pair.Key) > -1)
                  .Select(pair => pair.Value)
                  .FirstOrDefault();
