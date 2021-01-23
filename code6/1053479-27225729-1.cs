    interface IDoer<TKey>
    {
        void DoSomething(TKey foo);
    }
    
    class ImplA : IDoer<string>
    {
        public void DoSomething(string foo)
        {
            // do something
        }
    }
    
    class MyCache<TDoer, TKey> where TDoer : IDoer<TKey>, new()
    {
        public void DoSomething(TKey foo)
        {
            new TDoer().DoSomething(foo);
        }
    }
