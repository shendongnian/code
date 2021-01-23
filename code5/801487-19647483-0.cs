    using DebugTuple = Tuple<string, Func<string>>;
    class Program
    {  
        class Player
        {
            public int x;
            public Player(int y) { x = y; }            
        }
        static void Main(string[] args)
        {    
            Player one = new Player(25);
            Player two = new Player(50);
            List<DebugTuple> calls = new List<DebugTuple>();
            calls.Add(new DebugTuple("Player 1 health", delegate() { return one.x.ToString(); })); 
            calls.Add(new DebugTuple("Player 2 health", delegate() { return two.x.ToString(); })); 
            foreach (DebugTuple c in calls)
                Console.WriteLine(c.Item1 + ": " + c.Item2());
            //Change values and make sure it outputs new values
            one.x = 100;
            two.x = 0;
            foreach (DebugTuple c in calls)
                Console.WriteLine(c.Item1 + ": " + c.Item2());
            Console.ReadLine();
        }
      
    }
