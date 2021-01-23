    private void refresh_Click(object sender, RoutedEventArgs e)
            {
                this.NavigationCacheMode = NavigationCacheMode.Disabled;
                Refresh.IsEnabled = false;
                switch (flipView.SelectedIndex)
                {
                    case 0:
                        ApplicationData.Current.RoamingSettings.Values["FlipView"] = 0;
                        break;
                    case 1:
                        ApplicationData.Current.RoamingSettings.Values["FlipView"] = 1;
                        break;
                    case 2:
                        ApplicationData.Current.RoamingSettings.Values["FlipView"] = 2;
                        break;
                    case 3:
                        ApplicationData.Current.RoamingSettings.Values["FlipView"] = 3;
                        break;
                }
                this.Frame.Navigate(typeof(MainPage));
            }
