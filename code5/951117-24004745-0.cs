    class _24003458
    {
        event EventHandler MyEvent;
        public void Test()
        {
            MyEvent += Handler1;
            MyEvent += Handler2;
            MyEvent(this, EventArgs.Empty);
        }
        void Handler1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void Handler2(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
