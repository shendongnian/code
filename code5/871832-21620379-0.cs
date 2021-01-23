    private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            var item = listBox1.SelectedItem as Newss;
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("SelectedObject"))
            {
                IsolatedStorageSettings.ApplicationSettings["SelectedObject"] = item;
                title=item.News_Title;
                news_description=item.News_Description;
                NavigationService.Navigate(new Uri("/NewsDetails.xaml", UriKind.Relative));
            }
        }
