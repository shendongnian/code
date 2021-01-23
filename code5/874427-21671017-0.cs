        public interface IDoSomething
        {
            void DoSth();
        }
        
        class ViewModel<T> where T : IDoSomething
        {
            private T proxy;
        
            public ViewModel(T data)
            {
                proxy = data;
            }
        
            public void DoSth()
            {
                proxy.DoSth();
            }
        
            public T Proxy
            {
                get
                {
                    return proxy;
                }
            }
    }
