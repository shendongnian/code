      private void btnClassicPuzzle_Click(object sender, System.Windows.RoutedEventArgs e)
      {
        //play the globlal MediaElement 
         ((App)App.Current).playMedia(new Uri("/Sound/Lionsound.mp3", UriKind.Relative));
          NavigationService.Navigate(new Uri("/Menu/SelectPack.xaml", UriKind.Relative));
       }
