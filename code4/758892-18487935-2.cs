    static class Program {
        
        static void Main()
        {
            method1 objDel2;
            objDel2 = new method1(TestMethod1);
            objDel2("test");
            objDel2.Invoke("Invoke");
        }
        delegate void method1(string val);
        static void TestMethod1(string val) {
            System.Console.WriteLine(val);
        }
    }
