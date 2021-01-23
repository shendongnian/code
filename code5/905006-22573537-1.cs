    class MyClass: BindableBase
    {
            private int _b1;
            public int B1
            {
                get { return _b1; }
                set { SetProperty(ref _b1, value); }
            }
    }
