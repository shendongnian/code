    // obfuscated class
    public class MyClass
    {
        public MyClass()
        {
        }
        public void MyMethod()
        {
        }
    }
    // unobfuscated class
    public class CallingClass
    {
        public static void TestMyClass()
        {
            MyClass class = new MyClass();
            class.MyMethod();
        }
    }
