    ItemClick="ItemClick"
    private void ItemClick(object sender, ItemClickEventArgs e)
    {
            Video item = e.ClickedItem as Video;
            App.ViewModel.SelectedVideo = item;
            NavigationService.Navigate(new Uri("/PlayerPage.xaml,UriKind.Relative));
    }
