    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var frameworkElement = sender as FrameworkElement;
        var task = SimulateBackgroundWork(); 
        flyout.Closed += flyout_Closed;
        var mf1 = new MenuFlyoutItem { Text = "Option1" };
        var mf2 = new MenuFlyoutItem { Text = "Option2" };
        mf1.Click += mf_Click;
        mf2.Click += mf_Click;
        flyout.Items.Clear();
        flyout.Items.Add(mf1);
        flyout.Items.Add(mf2);
        await ShowMenuFlyout(sender as FrameworkElement);
        await task;
    }
