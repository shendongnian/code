    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MyBase> dic = new Dictionary<string, MyBase>();
            A<int> test= new A<int>();
            dic.Add("test", test);
        }
    }
    class MyBase
    { }
    class A<T> : MyBase
    {}
