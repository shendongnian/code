    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MyBase<object>> dic = new Dictionary<string, MyBase<object>>();
        }
    }
    class MyBase<T>
    { }
    class A : MyBase<int> 
    {}
