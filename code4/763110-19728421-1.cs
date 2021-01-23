    Dispatcher.Invoke(new Action(() =>
    {
        LoadPageLayout(page);
    }), DispatcherPriority.ContextIdle, null);
    private void LoadPageLayout(Dashboard.ViewModel.PageViewModel selectedPage)
    {
        var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerialize(dockingManager);
        serializer.LayoutSerializationCallback += (s, args) =>
        {
            args.Content = args.Content;
        };
        var layoutToRestore = selectedPage.GetLayout();
        if (!String.IsNullOrEmpty(layoutToRestore))
        {
            // Remove any existing LayoutDocumentPane
            var cleanedLayout = RemoveAllEmptyXmlNodes(layoutToRestore);
            StringReader textReader = new StringReader(cleanedLayout);
            serializer.Deserialize(textReader);
        }
    }
