    class Program
    {
        private static System.Timers.Timer _timer;
        static void Main( string[] args )
        {
            _timer = new System.Timers.Timer( 1000 );
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();
            Console.CursorLeft = 0;
            Console.CursorTop = 5;
            // Type something here...
            var l_readline = Console.ReadLine();
            // Print it out... (to show it correctly reads the input)
            Console.WriteLine( l_readline );
            Console.ReadKey( true );
        }
        private static void Timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            int l_left = Console.CursorLeft;
            int l_top = Console.CursorTop;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.Write( DateTime.Now.ToLongTimeString() );
            Console.CursorLeft = l_left;
            Console.CursorTop = l_top;
        }
    }
