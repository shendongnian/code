    public class ClosureClass1
    {
        public int i;
        public void Method1()
        {
            Console.WriteLine(i);
        }
    }
    public static void Foo()
    {
        ClosureClass1 closure = new ClosureClass1();
        closure.i = 0;
        int j = 1;
        Action a = closure.Method1;
    }
