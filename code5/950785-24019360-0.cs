    public void OnNavigatedTo(NavigationEventArgs e)
    {
        var frameState = SuspensionManager.SessionStateForFrame(this.Frame);
        this._pageKey = "Page-" + this.Frame.BackStackDepth;
        if (e.NavigationMode == NavigationMode.New)
        {
            var nextPageKey = this._pageKey;
            int nextPageIndex = this.Frame.BackStackDepth;
            while (frameState.Remove(nextPageKey))
            {
                nextPageIndex++;
                nextPageKey = "Page-" + nextPageIndex;
            }
            if (this.LoadState != null)
            {
                this.LoadState(this, new LoadStateEventArgs(e.Parameter, null));
            }
        }
        else
        {
            if (this.LoadState != null)
            {
                this.LoadState(this, new LoadStateEventArgs(e.Parameter, (Dictionary<String, Object>)frameState[this._pageKey]));
            }
        }
    }
