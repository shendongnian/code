    EventManager.RegisterClassHandler(typeof(FrameworkElement), ContextMenuOpeningEvent,
        new RoutedEventHandler(OnContextMenuOpening));
    private void OnContextMenuOpening(object sender, RoutedEventArgs e)
    {
        var control = (sender as FrameworkElement);
        var menu = control == null ? null : control.ContextMenu;
        if (menu != null)
        {
            var items = menu.Items.Cast<MenuItem>();
            if (items.All(i => i.Visibility != Visibility.Visible))
            {
                e.Handled = true;
            }
        }
    }
