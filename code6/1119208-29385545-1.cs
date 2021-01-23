    struct X
    {
        public string Y { get; set; }
        public X(string y) : this()
        {
            Y = y;
        }
    }
    X x = new X("abc");
    X x2 = x;
    x2.Y = "def";
    Console.WriteLine(x.Y);
    Console.WriteLine(x2.Y);
