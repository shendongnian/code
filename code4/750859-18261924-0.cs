    public static class FileInfoHelpers
    {
        private static Regex rxIso8601DateTimeValue = new Regex( @"\d{6,6}[Tt]\d{6,6}(\.\d+)$");
        private static readonly string[] formats = new string[]{
                                                        @"yyMMdd\tHHmmss.fffffff" ,
                                                        @"yyMMdd\THHmmss.fffffff" ,
                                                        } ;
        public static DateTime? TimestampFromName( this FileInfo fi )
        {
            DateTime? value = null ;
            Match m = rxIso8601DateTimeValue.Match( fi.Name ) ;
            if ( m.Success )
            {
                DateTime dt ;
                bool success = DateTime.TryParseExact( m.Value , formats , CultureInfo.InvariantCulture , DateTimeStyles.None , out dt  ) ;
                value = success ? dt : (DateTime?)null ;
            }
            return value ;
        }
    }
