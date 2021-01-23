    public delegate void TestDelegate(object sender, MyEventArgs e);
    MyEvent += (sender, e) =>
    {
        Observe(MyEvent);
    };
    void Observe(TestDelegate arg)
    {
    }
