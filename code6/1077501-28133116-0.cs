    protected override Window EnsureWindow(object model, object view, bool isDialog)
    {
        var window = view as Window;
        if (window == null)
        {
            window = new MyCustomWindowClass
            {                 
                SizeToContent = SizeToContent.WidthAndHeight
            };
            // I defined a ContentControl "WindowContent" in MyCustomWindow  
            // class to insert the window's contents
            ((MyCustomWindowClass)window).WindowContent.Content = view;
            window.SetValue(View.IsGeneratedProperty, true);
            var owner = InferOwnerOf(window);
            if (owner != null)
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                window.Owner = owner;
            }
            else
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
        else
        {
            var owner = InferOwnerOf(window);
            if (owner != null && isDialog)
            {
                window.Owner = owner;
            }
        }
        return window;
    }
