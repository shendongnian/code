    <phone:LongListSelector x:Name="myLSS" SelectionChanged="myLSS_SelectionChanged"/>
----------
    // event handler changes to
    private void myLSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LongListSelector lls = sender as LongListSelector;  // get lls
        var item = (SongItemModel) lls.SelectedItem;
        App.Model.ChangeSong(item.Id);   /// this code will create a audio track for this item
  
 
        // now your ObservableCollection is just the ItemsSource, save a reference to it
        // in the State manager so you can reference it on another page if you wish
        ObservableCollection<SongItemModel> obs = (ObservableCollection<SongItemModel>) lls.ItemsSource;
        PhoneApplicationService.Current.State["current_obs"] = obs;
        // navigate..............
        (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Pages/DetailSongPage.xaml", UriKind.Relative));                 
    }
