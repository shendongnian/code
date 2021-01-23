    using System;
    
    public interface ITest
    {
        void Wish();
    }
    
    public class Test : ITest
    {
        private readonly Action _wishAction;
    
        public Test(Action wish)
        {
            _wishAction = wish;
        }
    
        public void Wish()
        {
            _wishAction();
        }
    }
    
    class Program
    { 
        public static void Main(String[] args)
        {
            Test t = new Test(() => Console.WriteLine("output: hello how r u"));
            t.Wish();
        }  
    }
