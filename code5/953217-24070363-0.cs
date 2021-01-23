    private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            using (IsolatedStorageFile storeFile= IsolatedStorageFile.GetUserStoreForApplication())
            {
                StreamWriter sr = new StreamWriter(new IsolatedStorageFileStream("Browse_History.txt", FileMode.Append, storeFile));
                sr.WriteLine(e.Uri.ToString());
                sr.Close();
            }
        }
