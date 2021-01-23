    struct Person
    {
        public readonly int x;
    
        public Person( int x )
        {
            this.x = x;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int v = 9;
            Person p = new Person(v);
            Console.Write(p.x); // will output '9'
        } 
    }
