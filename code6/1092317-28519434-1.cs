    private static void OnClickHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var button = (Button)d;
        var data = (MyDataType)e.NewValue;
        button.Click += (btn, args) =>
        {
            // do action here based on data above
        }
    }
