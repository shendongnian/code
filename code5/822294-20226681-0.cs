    public struct X
    {
        public int a;
        public void setA(int value)
        { this.a = value; }
    }
    public struct Y
    {
        public int a { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            X x;
            x.a = 1; // A: okay
            x.setA(2); // B: error
            Y y;
            y.a = 3; // C: equivalent to B
        }
    }
