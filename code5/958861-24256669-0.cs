     // MainPage.Xaml
    private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SongsList selectedItemData = SelectedItem as SongsList ;
        if(selectedItemData != null)
        {
           NavigationService.Navigate(new Uri(string.Format("/AlbumPage.xaml?parameter={0}",selectedItemData.ID ), UriKind.Relative));
        }
    }
    //AlbumPAge.Xaml
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
    base.OnNavigatedTo(e);
    string parameter = this.NavigationContext.QueryString["parameter"];
 
    SongsList country = null;
     // GETS THE SONG COLLECTION HERE , UPDATE WHEN USER ADD TO PLAYLIST , AND RETURN BACK.
    }
    **If your doing on MVVM Way .This is just an Idea not tested.** 
      
