    class YourClass
    {
        private bool workFinished;
        public void DoWork()
        {
            MyMethod(instance => instance.Callback1Work(),
                     instance => instance.workFinished = false);
        }
        private void MyMethod(Action<YourClass> callback1,
                              Action<YourClass> callback2)
        {
            // Do whatever you want here...
            callback1(this);
            // And here...
            callback2(this);
        }
        private void Callback1Work()
        {
           // ...
        }
    }
