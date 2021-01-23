    interface IIncrementor
    {
        void Increment();
    }
    struct MyStruct : IIncrementor
    {
        public int i;
        public void Increment()
        {
            this.i = this.i + 1;
        }
        public override string ToString()
        {
            return i.ToString();
        }
    }
    // in some method:
    MyStruct ms = new MyStruct();
    ms.i = 42;
    Console.Writeline(ms); // 42
    object obj = ms;
    IIncrementable ii = (IIncrementable) ms;
    ii.Increment();
    Console.Writeline(ms); // still 42
    Console.Writeline(ii); // 43
