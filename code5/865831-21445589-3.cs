    class Program
    {
        static readonly Random _rng = new Random();
        static void Main(string[] args)
        {
            int stringCount = 2500;
            int initialStringSize = 100;
            int maxRng = 4;
            int numberOfPrepends = 2500;
            int iterations = 5;
            Console.WriteLine( "String Count: {0}; # of Prepends: {1}; # of Unique Chars: {2}", stringCount, numberOfPrepends, maxRng );
            var startingStrings = new List<string>();
            for( int i = 0; i < stringCount; ++i )
            {
                var sb = new StringBuilder( initialStringSize );
                for( int j = 0; j < initialStringSize; ++j )
                {
                    sb.Append( _rng.Next( 0, maxRng ) );
                }
                startingStrings.Add( sb.ToString() );
            }
            for( int i = 0; i < iterations; ++i )
            {
                TestUsingStringBuilderAppendWithReversedStrings( startingStrings, maxRng, numberOfPrepends );
                TestUsingStringBuilderPrepend( startingStrings, maxRng, numberOfPrepends );
            }
            
            var input = Console.ReadLine();
        }
        private static void TestUsingStringBuilderAppendWithReversedStrings( IEnumerable<string> startingStrings, int maxRng, int numberOfPrepends )
        {
            var builders = new List<StringBuilder>();
            var start = DateTime.Now;
            foreach( var str in startingStrings )
            {
                builders.Add( new StringBuilder( str ).Reverse() );
            }
            for( int i = 0; i < numberOfPrepends; ++i )
            {
                foreach( var sb in builders )
                {
                    sb.Append( _rng.Next( 0, maxRng ) );
                }
                builders.Sort( ( x, y ) =>
                {
                    var comparison = 0;
                    var xOffset = x.Length;
                    var yOffset = y.Length;
                    while( 0 < xOffset && 0 < yOffset && 0 == comparison )
                    {
                        --xOffset;
                        --yOffset;
                        comparison = x[ xOffset ].CompareTo( y[ yOffset ] );
                    }
                    if( 0 != comparison )
                    {
                        return comparison;
                    }
                    return xOffset.CompareTo( yOffset );
                } );
            }
            Parallel.ForEach( builders, sb => sb.Reverse() );
            var end = DateTime.Now;
            Console.WriteLine( "StringBuilder Reverse Append - Total Milliseconds: {0}", end.Subtract( start ).TotalMilliseconds );
        }
        private static void TestUsingStringBuilderPrepend( IEnumerable<string> startingStrings, int maxRng, int numberOfPrepends )
        {
            var builders = new List<StringBuilder>();
            var start = DateTime.Now;
            foreach( var str in startingStrings )
            {
                builders.Add( new StringBuilder( str ) );
            }
            for( int i = 0; i < numberOfPrepends; ++i )
            {
                foreach( var sb in builders )
                {
                    sb.Insert( 0, _rng.Next( 0, maxRng ) );
                }
                builders.Sort( ( x, y ) =>
                {
                    var comparison = 0;
                    for( int offset = 0; offset < x.Length && offset < y.Length && 0 == comparison; ++offset )
                    {
                        comparison = x[ offset ].CompareTo( y[ offset ] );
                    }
                    if( 0 != comparison )
                    {
                        return comparison;
                    }
                    return x.Length.CompareTo( y.Length );
                } );
            }
            var end = DateTime.Now;
            Console.WriteLine( "StringBulder Prepend - Total Milliseconds: {0}", end.Subtract( start ).TotalMilliseconds );
        }
    }
    public static class Extensions
    {
        public static StringBuilder Reverse( this StringBuilder stringBuilder )
        {
            var endOffset = stringBuilder.Length - 1;
            char a;
            for( int beginOffset = 0; beginOffset < endOffset; ++beginOffset, --endOffset )
            {
                a = stringBuilder[ beginOffset ];
                stringBuilder[ beginOffset ] = stringBuilder[ endOffset ];
                stringBuilder[ endOffset ] = a;
            }
            return stringBuilder;
        }
    }
