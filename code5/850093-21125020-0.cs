    public bool Reload()
    {
        if (!this.Frame.BackStack.Any())
            return false;
        var current = this.Frame.BackStack.First();
        this.Frame.BackStack.Remove(current);
        return this.Frame.Navigate(current.SourcePageType, current.Parameter);
    }
