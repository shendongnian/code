    class Program
    {
        static void Main( string[] args )
        {
            var cd = new System.Collections.Concurrent.ConcurrentDictionary<int, int>();
            var a = 0;
            var b = 1;
            var c = 2;
            cd[ 1 ] = a;
            Task.WaitAll(
                Task.Factory.StartNew( () => cd.AddOrUpdate( 1, b, ( key, existingValue ) =>
                    {
                        Console.WriteLine( "b" );
                        if( existingValue < b )
                        {
                            Console.WriteLine( "b update" );
                            System.Threading.Thread.Sleep( 2000 );
                            return b;
                        }
                        else
                        {
                            Console.WriteLine( "b no change" );
                            return existingValue;
                        }
                    } ) ),
                Task.Factory.StartNew( () => cd.AddOrUpdate( 1, c, ( key, existingValue ) =>
                {
                    Console.WriteLine( "c start" );
                    if( existingValue < c )
                    {
                        Console.WriteLine( "c update" );
                        return c;
                    }
                    else
                    {
                        Console.WriteLine( "c no change" );
                        return existingValue;
                    }
                } ) ) );
            Console.WriteLine( "Value: {0}", cd[ 1 ] );
            var input = Console.ReadLine();
        }
    }
