    public void ShowView<T>(params ParameterOverride[] parameter)
    {
        var window = UnityServiceConfigurator.Instance.Container.Resolve<T>(parameter) as MetroWindow;
    
        if (window != null)
        {
            if (Application.Current.MainWindow != window)
            {
                window.Owner = Application.Current.MainWindow;
                var ownerMetroWindow = (window.Owner as MetroWindow);
    
                if (!ownerMetroWindow.IsOverlayVisible())
                    ownerMetroWindow.ShowOverlayAsync();
            }
    
            if (!_openedViews.Contains(window))
                _openedViews.Add(window);
    
            window.Show();
        }
    }
