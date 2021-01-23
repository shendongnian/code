     private async void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            {
                
                var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Session), itemId));
                
            }
        }
