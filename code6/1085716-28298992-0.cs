    internal delegate void MyDelegate(string s);
    public class Foo
    {
        public void F()
        {
            MyDelegate del = delegate { Console.WriteLine("hello!"); };
        }
    }
