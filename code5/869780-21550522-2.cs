    private void newlonglist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
          IsolatedStorageSettings MemorySettings = IsolatedStorageSettings.ApplicationSettings;
            LongListSelector selector = sender as LongListSelector;
            if (selector == null)
                return;
            newpatterns newdata = selector.SelectedItem as newpatterns;
            if (newdata == null)
                return;
            //MessageBox.Show(newdata.Hex);
            MemorySettings.Add("SelectedItem",newdata );
            NavigationService.Navigate(new Uri("/NewImagePage.xaml, UriKind.Relative));        
        }
 
