    class App
    {
        public SomeDataStorage MyData;
        public App()
        {
            Reset();
        }
        // call this when you need to init for the first time or simply reset to default
        public void Reset()
        {
            MyData = new SomeDataStorage();
        }
    }
