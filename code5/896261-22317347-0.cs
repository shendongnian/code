    private async void setLocationBtn_Click(object sender, RoutedEventArgs e)
       { 
         await this.GetCoordinates();
        PhoneApplicationService.Current.State["Data"] = your data;
         NavigationService.Navigate(new Uri("/Maps.xaml", UriKind.Relative));
        }
    
    //On Second page
    
     protected override void OnNavigatedTo(NavigationEventArgs e)
        {
         var data =PhoneApplicationService.Current.State["Data"] as Cast your type
         PhoneApplicationService.Current.State.Remove("Data");
        }
