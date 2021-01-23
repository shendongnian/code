        static void Main()
        {
            List<Task> tasks = new List<Task>();
            for( int i = 0; i < 10; ++i )
            {
                tasks.Add( Task.Factory.StartNew( () => ThreadFunc() ) );
            }
            // need this to keep process alive
            // will continue once all tasks complete
            Task.WaitAll( tasks.ToArray() );
        }
