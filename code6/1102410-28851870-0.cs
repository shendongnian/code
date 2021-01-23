    public void test()
    {
        BackgroundMethodDelegate c = new BackgroundMethodDelegate(Background);
        IAsyncResult a = c.BeginInvoke("test", null, null);
        c.EndInvoke(a);
    }
