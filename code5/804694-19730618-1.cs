    public sealed class Int : Summable<int>
    {
        protected int n;
        public Int(int n)
        {
           if(n < 0)
               throw new ArgumentException("n must be a non negative."); 
           this.n = n;
        }
        public override Summable<int> Add1()
        {
            return new Int(n + 1);
        }
        public override Summable<int> Sub1()
        {
            return new Int(n - 1);
        }
        public override Summable<int> Zero
        {
            get
            {
                return new Int(0);
            }
        }
        public override Summable<int> One
        {
            get
            {
                return new Int(1);
            }
        }
        public override bool Equals(Summable<int> other)
        {
            var x = other as Int;
            if (Object.ReferenceEquals(x, null))
                return false;
            return this.n == x.n;
        }
        public override string ToString()
        {
            return n.ToString();
        }
    }
