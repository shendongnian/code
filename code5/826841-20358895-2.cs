    class YourClass
    {
        private readonly Action foo;
        private readonly Action bar;
        private bool workFinished;
        public YourClass()
        {
            foo = Callback1Work;
            bar = () => workFinished = false;
        }
        public void DoWork()
        {
            MyMethod(foo, bar);
        }
   
        public void MyMethod(Action callback1, Action callback2)
        {
            ...
        }
        private void Callback1Work()
        {
            ...
        }
    }
