    IDisposable DumpLatest<T> (IObservable<T> obs)
    {
        var dc = new DumpContainer ().Dump();
        var extensionToken = Util.GetQueryLifeExtensionToken();
        return obs.Subscribe (
            value => dc.Content = value,
            ex => { dc.Content = ex; extensionToken.Dispose(); },
            () => extensionToken.Dispose());
    }
