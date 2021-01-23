    public void Dispose()
    {
       this.Stop();
       this.Close();
       this.Dispatcher.InvokeShutdown();
    }
