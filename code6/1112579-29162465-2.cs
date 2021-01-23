    void Main()
    {
        var f1 = Test1();
        f1(10).Dump();
        f1.Dump();
    
        var f2 = Test2();
        f2(10).Dump();
        f2.Dump();
    }
    
    public Func<int, int> Test1()
    {
        int a = 42;
        return value => a + value;
    }
    
    public Func<int, int> Test2()
    {
        var dummy = new c__DisplayClass1();
        dummy.a = 42;
        return dummy.b__0;
    }
    
    public class c__DisplayClass1
    {
        public int a;
        public int b__0(int value)
        {
            return a + value;
        }
    }
