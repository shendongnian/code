    public class Stack<T> : Sequence<T> 
    { 
        public override void Push(T value)
        {
            stk.Add(value);
        }
        .... 
    }
