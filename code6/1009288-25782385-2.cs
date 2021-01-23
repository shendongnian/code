    Window w = Window.GetWindow(this);
    if(null != w)
    {
        ((UserControl)w.FindName("a")).Visibility = Visibility.Hidden;
        ((UserControl)w.FindName("b")).Visibility = Visibility.Visible;
    }
