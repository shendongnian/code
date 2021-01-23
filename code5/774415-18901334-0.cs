    delegate void MyAction<T,T1>(ref T a, T1 b);
    static void Main(string[] args)
        {
            MyAction<string, int> action = Foo;            
            var arr = new object[] { "", 5 };
            action.DynamicInvoke(arr);
        }
        private static void Foo(ref string a, int b)
        {
            a = b.ToString();
        }
