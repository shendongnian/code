    public class CustomComparer : Comparer<string> {
            Dictionary<string, int> hash;
            public CustomComparer( ) {
               var tokens = "Application5, Application2, Application4, Application3"
                            .Split( ',' )
                            .Select( s => s.Trim( ) )
                            .ToArray( );
               hash = Enumerable.Range(0, tokens.Length)
                                .ToDictionary( i => tokens[i]  );
            }
            public override int Compare( string x, string y ) {
                return hash[x] - hash[y];
            }
            public static readonly CustomComparer Default = new CustomComparer();
        }
