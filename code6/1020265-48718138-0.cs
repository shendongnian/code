            public List<string> getCurrencyCode()
            {
                List<string> CountryList = new List<string>();
                List<string> CurrencyList = new List<string>();
                CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            
                foreach (CultureInfo getCulture in getCultureInfo)
                {
                     RegionInfo ri = new RegionInfo(getCulture.LCID);
                    //Region includes country name and currency symbols
                    //make sure no repeats
                    if (!(CountryList.Contains(ri.EnglishName))) 
                    {
                       CountryList.Add(ri.EnglishName);
                       CurrencyList.Add(ri.ISOCurrencySymbol);                    
                    }
               }
                return CurrencyList;
            }
