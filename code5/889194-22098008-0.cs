    public class Epos
    {
        protected Epos(int x) { this.X=x; }
        public Epos(Epos other) { this.X=other.X; }
        public int X { get; protected set; }
    }
    public class Epos2 : Epos
    {
        public Epos2(int x, string s) : base(x) { this.S=s; }
        public Epos2(Epos other, string s) : base(other) { this.S=s; }
        public Epos2(Epos2 other) : base(other) { this.S=other.S; }
        public string S { get; protected set; }
    }
    // call as:
    // var A = new Epos2(1,"A");
    // var b = new Epos(2);
    // var B = new Epos2(b, "B");
