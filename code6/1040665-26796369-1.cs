    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        Type lastPage = null;
        switch (e.NavigationMode)
        {
            case NavigationMode.New:
            case NavigationMode.Forward:
                if (Frame.BackStack.Count > 0)
                    lastPage = Frame.BackStack.Last().SourcePageType;
                break;
            case NavigationMode.Back:
                if (Frame.ForwardStack.Count > 0)
                    lastPage = Frame.ForwardStack.Last().SourcePageType;
                break;
            default:
                // TODO
                break;
        }
        if (lastPage != null)
            System.Diagnostics.Debug.WriteLine("Last page was {0}", lastPage);
    }
