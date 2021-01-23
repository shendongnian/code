    class Program
    {
        static void Main(string[] args)
        {
            IntClass c1 = new IntClass();
            c1.MyMethod(12);
            BaseClass<string> c2 = new BaseClass<string>();
            c2.MyMethod("hello world");
        }
    }
    class BaseClass<T>
    {
        public virtual void MyMethod(T t)
        {
            Console.WriteLine(string.Format("Param: {0}", t));
        }
    }
    class IntClass : BaseClass<int>
    {
        public override void MyMethod(int myVar)
        {
            Console.WriteLine(string.Format("Param: int"));
        }
    }
