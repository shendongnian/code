    interface IMyInterface
    {
        void Foo();
    }
    class MyClass
    {
        public void Bar()
        {
            var obj = new MyInterface();
            obj.Foo();
        }
        private class MyInterface : IMyInterface
        {
            public void Foo()
            {
                // stuff
            }
        }
    }
