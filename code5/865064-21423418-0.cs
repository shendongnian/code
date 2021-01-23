    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem( new WaitCallback( PrintNumbers ) );
    }
    static void PrintNumbers(object a)
    {
      for ( int i = 0; i < 10; i++ )
         {
            Console.WriteLine( i );
            Thread.Sleep( 3000 );
         }
    }
