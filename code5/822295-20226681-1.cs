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
            x.setA(1); // A: error
            x.a = 2; // B: okay
            Y y;
            y.a = 3; // C: equivalent to A
        }
    }
