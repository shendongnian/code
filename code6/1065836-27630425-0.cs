    class CountryCodeMap
    {
      private static Dictionary<string,string> map =
        CultureInfo
        .GetCultures(CultureTypes.AllCultures)
        .Where( ci => ci.ThreeLetterISOLanguageName != "ivl" )
        .Where( ci => !ci.IsNeutralCulture )
        .Select( ci => new RegionInfo(ci.LCID) )
        .Distinct()
        .ToDictionary( r => r.Name , r => r.EnglishName )
        ;
      public static string GetCountryName( string isoCountryCode )
      {
        string countryName ;
        bool found = map.TryGetValue( isoCountryCode, out countryName ) ;
        if ( !found ) throw new ArgumentOutOfRangeException("isoCountryCode") ;
        return countryName ;
      }
    }
