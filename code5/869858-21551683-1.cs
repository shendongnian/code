        public delegate Task<T> MyFunc<T>() where T : MyClass;
        public Task<MyClass<int>> ff(MyFunc<MyClass<int>> f)
        {
            return f.Invoke();
        }
        public void aa()
        {
            ff(() => Task<MyClass<int>>.Run(() => new MyClass<int>()));
        }
