    public static class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
        }
    }
    class A
    {
        public A()
        {
            B();
        }
        [MethodImplOptions.NoInlining]
        private void B([CallerMemberName] string caller = null)
        {
            if (caller == ".ctor")
            {
            }
        }
    }
