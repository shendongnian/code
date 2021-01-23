    public Window CreateWindowHostingViewModel(object viewModel, bool sizeToContent)
    {
       ContentControl contentUI = new ContentControl();
       contentUI.Content = viewModel;
       DockPanel dockPanel = new DockPanel();
       dockPanel.Children.Add(contentUI);
       Window hostWindow = new Window();
       hostWindow.Content = dockPanel;
       if (sizeToContent)
           hostWindow.SizeToContent = SizeToContent.WidthAndHeight;
       return hostWindow;
    }
