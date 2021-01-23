          protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
          {
               //get the bitmapImage
               BitmapImage bitmapGet = PhoneApplicationService.Current.State["yourparam"] as BitmapImage;
             
               //set the bitmpaImage 
               img.Source = bitmapGet;
 
               base.OnNavigatedTo(e);
          }
