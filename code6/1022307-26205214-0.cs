    public virtual void OnEndRequest()
    {
        var disposables = RequestContext.Instance.Items.Values;
        foreach (var item in disposables)
        {
            Release(item);
        }
    
        RequestContext.Instance.EndRequest();
    }
    
    public virtual void Release(object instance)
    {
        try
        {
            var iocAdapterReleases = Container.Adapter as IRelease;
            if (iocAdapterReleases != null)
            {
                iocAdapterReleases.Release(instance);
            }
            else
            {
                var disposable = instance as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
        }
        catch { /*ignore*/ }
    }
