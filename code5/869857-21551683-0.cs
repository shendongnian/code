        public delegate Task<T> MyFunc<T>();
        public Task<int> ff(MyFunc<int> f)
        {
            return f.Invoke();
        }
        public void aa()
        {
            ff(() => Task<int>.Run(() => 5 ));
        }
