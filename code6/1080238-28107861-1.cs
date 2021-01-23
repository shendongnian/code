    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        element.Dispatcher.BeginInvoke(new Action<UIElement>(x =>
        {
            x.Focus();
        }), DispatcherPriority.ApplicationIdle, element);
    }
