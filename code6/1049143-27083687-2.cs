    public Task DoSomethingAsync()
    {
        return Task.Factory.StartNew(
            () => HarpaEngine.DeassignMP3toHymns()
        );
    }
    public void StopAnimation()
    {
        //stop storyboard
    }
