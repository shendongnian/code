    static void Main( string[] args )
    {
        List<int> store = new List<int>();
        for( int i = 0; i < 100; i++ )
            store.Add( i );
        FindValue( store );
        FindSum( store );
        Console.ReadLine();
    }
    static void FindValue( List<int> list )
    {
        for( int i = 0; i < list.Count; i++ )
        {
            if( list[i] == 40 )
                Console.WriteLine( "Value is 40" );
        }
    }
    static void FindSum( List<int> list )
    {
        int sum = 0;
        for( int i = 0; i < list.Count; i++ )
            sum += list[i];
        Console.WriteLine( "The sum is {0}", sum );
    }
