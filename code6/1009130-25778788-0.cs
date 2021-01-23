    using System;
    
    public interface IWrapper<out T>
    {
        T Value { get; }
    }
    
    public class Wrapper<T> : IWrapper<T>
    {
        private readonly T value;
        
        public Wrapper(T value)
        {
            this.value = value;
        }
        
        public T Value { get { return value; } }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IWrapper<string> original = new Wrapper<string>("foo");
            IWrapper<object> original2 = original;        
            IWrapper<object> rewrapped = Rewrap(original2);
            
            Console.WriteLine(original2.GetType()); // Wrapper<string>
            Console.WriteLine(rewrapped.GetType()); // Wrapper<object>
        }
    
        static IWrapper<T> Rewrap<T>(IWrapper<T> wrapper)
        {
            return new Wrapper<T>(wrapper.Value);
        }    
    }
