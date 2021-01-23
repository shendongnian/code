    class C : I<char>
    {
        public char Value { get; set; }
        public Tuple<char, U> F<U>(U u)
        {
            return Tuple.Create(Value, u);
        }
    }
