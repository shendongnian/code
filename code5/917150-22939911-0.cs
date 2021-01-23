    public class Something
    {
        private readonly IIndex<string, IService> index;
        public Something(IIndex<string, IService> index)
        {
            this.index = index;
        }
    
        public void DoStuff()
        {
            this.index["someString"].Send();
        }
    }
    
    public interface IIndex<TKey, TValue>
    {
        TValue this[TKey index] {get;set;}
    }
    
    public interface IService
    {
        void Send();
    }
