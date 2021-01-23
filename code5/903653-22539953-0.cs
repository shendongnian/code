    public object RunOnUiThread(Delegate method)
    {
        return Dispatcher.Invoke(DispatcherPriority.Normal, method);
    }
...
    RunOnUiThread((Action)delegate
    {
        currentposition = Bass.BASS_ChannelGetPosition(stream);
    });
