    // Background thread calls this method
    public async void Object_Callback()
    {
        Debug.WriteLine("Object_Callback() has been called.");
        var buttonLabel = await Dispatcher.RunTaskAsync(ShowMessageAsync);
        Debug.WriteLine($"Object_Callback() is running again. User clicked {buttonLabel}.");
    }
