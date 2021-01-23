    private void longList_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           if (PhoneApplicationService.Current.State.ContainsKey("Data"))
              if (PhoneApplicationService.Current.State["Data"] != null)
                   PhoneApplicationService.Current.State.Remove("Data");
             LongListSelector selector = sender as LongListSelector;
             Writing data = selector.SelectedItem as Writing;
             PhoneApplicationService.Current.State["Data"] = data ;
             NavigationService.Navigate(new Uri("/WritingPage.xaml", UriKind.Relative));     
        }
     
    //On second page
    //I assume you want to Data on page load
    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          Writing data = new Writing ();
         data =(Writing)PhoneApplicationService.Current.State["Data"]
         PhoneApplicationService.Current.State.Remove("Data");    
        }
