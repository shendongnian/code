    public object ViewLoaded
    {
        get
        {
            OnViewLoaded();
            return null;
        }
    }
    protected virtual void OnViewLoaded() { }
