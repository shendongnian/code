     public MainViewModel()
        {
            Messenger.Default.Register<string>(this, (action) =>
            {
                if (action == "MainLoaded")
                {
                    MyClass cls = new MyClass();
                    cls.MyFunction();
                }
            });
       }
