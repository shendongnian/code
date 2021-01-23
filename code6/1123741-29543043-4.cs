    public async void EventHandler(object sender, EventArgs e)
    {
        _tcs = new TaskCompletionSource<bool>();
        await _tcs.Task;
    }
    
    public void UIChanged(object sender, EventArgs e)
    {
        _tcs.SetResult(false);
    }
