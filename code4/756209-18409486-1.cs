    public class SomeClass 
    {
        private int x;
        private int y;
    
        public SomeClass () : this(90,90) { }
        public SomeClass(int x, int y) { this.x = x; this.y = y; }
        public void ShowMeValues ()
        {
            Console.WriteLine(this.x);
            Console.WriteLine(this.y);
        }
    }
