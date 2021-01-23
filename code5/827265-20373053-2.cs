    public abstract class CoinStack<T> : ICoinStack where T: Coin
    {
        private Queue<T> _stack = new Queue<T>();
        public T Pop() { return _stack.Dequeue(); }
        Coin ICoinStack.Pop() {return this.Pop(); }
        public void Push(T item) { _stack.Enqueue(item); }
        void ICoinStacl.Push(Coin item) { this.Push((T) item);
    }
