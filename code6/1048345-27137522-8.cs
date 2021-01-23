    public void Dispose()
    {
         SendRawMessage("QUIT :");
         _closing = true;
    }
