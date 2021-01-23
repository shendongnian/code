    class Thing
    {
        public string A { get; set; }
        public int B { get; set; }
        public Thing(string a, int b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", B, A);
        }
    }
