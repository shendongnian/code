    private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       Uri uri = new Uri("/News.xaml", UriKind.Relative);
       if (uri != (Application.Current.RootVisual as PhoneApplicationFrame).CurrentSource)
       {
           NavigationService.navigate(uri);
       }
    }
