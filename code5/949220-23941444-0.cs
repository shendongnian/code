    private void Button_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        DockPanel dockPanel = (DockPanel)((Button)sender).Content;
        TextBlock text = (TextBlock)LogicalTreeHelper.FindLogicalNode(dockPanel, "secondTextBlock");
        if (text != null)
        {
            text.Visibility = Visibility.Visible;
        }
    }
