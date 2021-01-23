    public void test()
    {
        BackgroundDelegate c = new BackgroundMethodDelegate(Background);
        IAsyncResult a = c.BeginInvoke("test", null, null);
        c.EndInvoke(a);
    }
