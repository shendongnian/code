    public class hello : JavascriptFunction<hello, hello.signature>
    {
        public delegate void signature(string world, bool goodByeToo);
        public hello() : base(@"return 'Hello ' + world + (goodByeToo ? '. And good bye too!' : ''") {}
    }
    public class bye : JavascriptFunction<bye, bye.signature>
    {
        public delegate void signature(string friends, bool bestOfLuck);
        public bye() : base(@"return 'Bye ' + friends + (bestOfLuck ? '. And best of luck!' : ''") {}
    }
