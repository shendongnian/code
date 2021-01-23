    static class Program
    {
        
        class ListEqualityComparer : IEqualityComparer<List<int>>
        {
            public bool Equals( List<int> x, List<int> y )
            {
                return ( x.Count == y.Count ) && new HashSet<int>( x ).SetEquals( y );
            }
            public int GetHashCode( List<int> list )
            {
                int hash = 19;
                foreach( int val in list )
                {
                    hash = hash * 31 + val.GetHashCode();
                }
                return hash;
            }
        }
        //Fill is just a method to fill the original lists for testing
        static void Fill( List<List<int>> toFill )
        {
            Console.WriteLine( "Fill" );
            for( int i = 1; i <= 5; i++ )
            {
                Console.Write( "( " );
                List<int> newList = new List<int>();
                toFill.Add(newList);
                for( int j = 1; j <= i%2 + 1; j++ )
                {
                    newList.Add( j );
                    Console.Write( j + " " );                    
                }
                Console.WriteLine( ")" );
            }
        }
        static void Main( string[] args )
        {
            List<string> result = new List<string>();
            List<List<int>> fnc = new List<List<int>>();
            Fill( fnc );
            var results = fnc.Distinct( new ListEqualityComparer() );
            Console.WriteLine( "De-dupe" );
            foreach( var list in results )
            {
                Console.Write( "( " );
                foreach( var element in list )
                {
                    Console.Write( element + " " );
                }
                Console.WriteLine( ")" );
            }
        }
    }
