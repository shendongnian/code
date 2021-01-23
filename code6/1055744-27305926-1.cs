    public event EventHandler<StringEventArgs> OutputRaised;
    protected virtual void OnWriteText(string e)
    {
        var handle = this.OutputRaised;
        if (handle != null)
        {
            var message = string.Format("({0}) : {1}", this.Port, e);
            handle(this, new StringEventArgs(message));
        }
    }
