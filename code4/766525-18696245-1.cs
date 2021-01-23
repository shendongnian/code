    class Program
    {
        public delegate void mydel();
        public static event mydel myevent;
    
        static void del()
        {
            Console.WriteLine("Called in del");
    
        }
    
        static void Main(string[] args)
        {
            myevent += new mydel(del);
            myevent();
            Console.ReadLine();
    
        }
    }
