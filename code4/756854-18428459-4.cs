    public interface INamed {
       string Name {get;}
    }
    public class CustomComparer : Comparer<INamed> {
            Dictionary<string, int> hash;
            public CustomComparer( ) {
               var tokens = "Application5, Application2, Application4, Application3"
                            .Split( ',' )
                            .Select( s => s.Trim( ) )
                            .ToArray( );
               hash = Enumerable.Range(0, tokens.Length)
                                .ToDictionary( i => tokens[i]  );
            }
            public override int Compare( INamed x, INamed y ) {
                return hash[x.Name] - hash[y.Name];
            }
            public static readonly CustomComparer Default = new CustomComparer();
        }
