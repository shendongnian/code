    private void AcceptsEventHandler(Action<object, DataGridViewCellEventArgs> handler)
    {
        // handler is SomeEventHandler if we call:
        //           AcceptsEventHandler(SomeEventHandler);
        handler(this, new DataGridViewCellEventArgs(1, 2));
    }
    private void SomeEventHandler(object sender, EventArgs e)
    {
       // We are getting a DataGridViewCellEventArgs as second argument here, which is ok.
    }
