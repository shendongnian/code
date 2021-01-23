    private bool IsItemClickDisabled;
    
    private void TextTapped(object sender, TappedRoutedEventArgs e)
    {
       IsItemClickDisabled = true;
       //TODO: Your tap event handler
    
       e.Handled = true;
    }
    
    private async void ItemClickHandler(object sender, ItemClickEventArgs e)
    {
       IsItemClickDisabled = false; //Reset each time
       await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(1));
       if (!IsItemClickDisabled)
       {
          //TODO: ItemClick handler
       }
    }
