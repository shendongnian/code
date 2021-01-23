    public Wrapper<T>
       where T : IMyInterface, new()
    {
        public IMyInstance instance { get; set; }
        public Wrapper()
        {
            instance = new T();
            instance.Run();
        }
    }
