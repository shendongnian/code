    private void AsyncCallback(IAsyncResult ar)
    {
        Action handler = ar.AsyncState as Action;
        var result = handler.EndInvoke(ar);               
    }
