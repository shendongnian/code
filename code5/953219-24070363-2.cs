        private void btnSaveToFavorties_Click(object sender, RoutedEventArgs e)
        {
         using (IsolatedStorageFile appStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                StreamWriter sr = new StreamWriter(new IsolatedStorageFileStream("Browser_Favorties.txt", FileMode.Append, appStore));
                sr.WriteLine(webBrowser.Source.ToString());
                sr.Close();
            }
     }
