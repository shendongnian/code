    private void GridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
    {
        var itemContainer = (GridViewItem)this.MyGridView.ContainerFromItem(e.Items[0]);
    
        // get drag item position
        var position = itemContainer.GetRelativePosition(this.LayoutRoot);
    
        // set the width and height of the image
        this.DropItemImage.Width = itemContainer.ActualWidth;
        this.DropItemImage.Height = itemContainer.ActualHeight;
    
        // move the image to this location
        this.DropItemImage.RenderTransformOrigin = new Point(0, 0);
        this.DropItemImage.RenderTransform.Animate(null, position.X, "TranslateX", 0, 0);
        this.DropItemImage.RenderTransform.Animate(null, position.Y, "TranslateY", 0, 0);
    }
    
    private void GridView_Drop(object sender, DragEventArgs e)
    {
        // reset the image
        this.DropItemImage.Source = null;
    }
    
    private object _previous;
    private async void ItemRoot_DragOver(object sender, DragEventArgs e)
    {
        // first we get the DataContext from the drop item in order to retrieve its container
        var vm = ((Grid)sender).DataContext;
    
        // get the item container
        var itemContainer = (GridViewItem)this.MyGridView.ContainerFromItem(vm);
    
        // this is just to stop the following code to be called multiple times druing a DragOver
        if (_previous != null && _previous == itemContainer)
        {
            return;
        }
        _previous = itemContainer;
    
        // copy the look of the drop item to an image
        var bitmap = new RenderTargetBitmap();
        await bitmap.RenderAsync(itemContainer);
        this.DropItemImage.Source = bitmap;
    
        // animate the image to make its appearing more interesting
        this.DropItemImage.Animate(0, 0.4, "Opacity", 200, 0);
        this.DropItemImage.RenderTransformOrigin = new Point(0.5, 0.5);
        this.DropItemImage.RenderTransform.Animate(0.8, 1, "ScaleX", 200, 0, new ExponentialEase { EasingMode = EasingMode.EaseIn });
        this.DropItemImage.RenderTransform.Animate(0.8, 1, "ScaleY", 200, 0, new ExponentialEase { EasingMode = EasingMode.EaseIn });
    }
