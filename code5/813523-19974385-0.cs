        static public void Start_Adventure()
        {
            ...
            input_name(BoyorGirl);
            ...
        }
        public static void input_name(string BoyorGirl)
        {
            Console.WriteLine("You're just a normal {0}, called.. input your name please.");
            string name;
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You're just a normal {0}, called {1}..", BoyorGirl, name); //The error appears here.
        }
