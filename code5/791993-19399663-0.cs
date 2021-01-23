    private void Application_Launching(object sender, LaunchingEventArgs e)
            {
                if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
                {
                    Uri newUri = new Uri("/PlayerPage.xaml", UriKind.Relative);
                    ((App)Application.Current).RootFrame.Navigate(newUri);
                }
            }
