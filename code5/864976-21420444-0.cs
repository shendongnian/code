    class Program
    {
        static void Main()
        {
            DateTime now;
            not = DateTime.Now;
            for( int i = 0; i < 10; ++i )
            {
                Task.WaitAll( Task.Delay( 1000 ) );
            }
            // result: 10012.57xx - 10013.57xx ms
            Console.WriteLine( DateTime.Now.Subtract( now ).TotalMilliseconds );
            
            now = DateTime.Now;
            for( int i = 0; i < 10; ++i )
            {
                Thread.Sleep( 1000 );
            }
            // result: *always* 10001.57xx
            Console.WriteLine( DateTime.Now.Subtract( now ).TotalMilliseconds );
            Console.ReadLine();
        }
    }
