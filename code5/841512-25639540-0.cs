    ResourceManager.Current.DefaultContext.QualifierValues.MapChanged += async (s, m) =>
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            ResourceManager.Current.DefaultContext.Reset();
            // other update code like myLabel.Text = ...
        });
    };
