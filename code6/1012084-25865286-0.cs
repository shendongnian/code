    public interface IMyInterface
    {
        void Select(Action<int, int> selector, int a, int b);
    }
    public class MyClass : IMyInterface
    {
        public void func(int a, int b=1 )
        {
            //body of function
        }
        public void Select(Action<int, int> action, int a, int b)
        {
            action(a, b);
        }       
    }
    class Program 
    {        
        static void Main(string[] args)
        {
            MyClass cls = new MyClass();
            cls.Select(cls.func, 10, 20);
        }
    }
