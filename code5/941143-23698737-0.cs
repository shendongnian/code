    class M
    {
        internal string n;
        internal M() { }
        internal M(string N)
        {
            Console.WriteLine("in base " + N);
            n = N;
        }
    }
    class D : M
    {
        internal D(string N) : base(N) { n = "DVD:" + N; }
    }
    static void Main(string[] args)
    {
        M d1 = new D("DVD");
        M m1 = new M("Unknown");
        Console.WriteLine("d1.n is " + d1.n);
    }
