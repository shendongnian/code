    private void ListOnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        var viewer = args.ItemContainer.ContentTemplateRoot as View;
        if (viewer == null)
        {
            return;
        }
        if (args.InRecycleQueue)
        {
            viewer.ClearData();
        }
        else if (args.Phase == 0)
        {
            viewer.ShowPlaceholder(args.Item as ViewModel);
            args.RegisterUpdateCallback(1, this.ContainerContentChangingDelegate);
        }
        else if (args.Phase == 1)
        {
            // Load
            args.RegisterUpdateCallback(2, this.ContainerContentChangingDelegate);
        }
        else if (args.Phase == 2)
        {
            // Load more
            args.RegisterUpdateCallback(3, this.ContainerContentChangingDelegate);
        }
        else if (args.Phase == 3)
        {
            // Show images
        }
        args.Handled = true;
    }
