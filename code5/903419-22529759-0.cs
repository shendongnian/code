    private void play_Click(object sender, RoutedEventArgs e)
            {
                MediaElement Click = new MediaElement();
                Click.Source = new Uri ("/Assets/Sounds/press.mp3",UriKind.Relative);
                Click.Position = TimeSpan.Zero;
                Click.Volume = 1;
                LayoutRoot.Children.Add(Click);
                Click.MediaEnded += Click_MediaEnded;
                Click.Play();
            }
    
    void Click_MediaEnded(object sender, RoutedEventArgs e)
           {
                NavigationService.Navigate(new Uri("/NavPage.xaml", UriKind.Relative));
           }
