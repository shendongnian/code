    public interface ISequence <T>
    {
        void Push(T value);
        T Pop();
        ...
    }
        
    public class Stack<T> : ISequence<T>
    {    
        public void Push(T value)
        {
            stk.Add(value);
        }
        ...
    }
   
