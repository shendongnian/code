        public static DateTime ParseAsZuluTime( string iso8601ZuluTime )
        {
          const DateTimeStyles style = DateTimeStyles.AssumeUniversal
                                     | DateTimeStyles.AdjustToUniversal
                                     ;
          DateTime value = DateTime.ParseExact( iso8601ZuluTime , formats , CultureInfo.InvariantCulture , style ) ;
          return value ;
        }
        static readonly string[] formats = {
          "yyyy-MM-ddTHH:mm:ss.fffK" , // K accepts
          "yyyy-MM-ddTHH:mm:ss.ffK"  , // the 'Z' suffix
          "yyyy-MM-ddTHH:mm:ss.fK"   , // or no suffix
          "yyyy-MM-ddTHH:mm:ssK"     ,
          "yyyy-MM-ddTHH:mm:ssK"     ,
          } ;
