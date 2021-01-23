    DtoThemePage[] dtoThemePageArrayFull = (from tpc in dboThemePageCountryList group tpc by tpc.DboThemePage.Keyword into k
                                            select new DtoThemePage
                                            {
                                                Keyword = k.Key,
                                                CountryCodes = k.Select(c => c.DboCountry.CountryCode).ToArray<string>()
                                            }).ToArray<DtoThemePage>();
