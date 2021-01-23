         using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream("myHtmlFile.txt", FileMode.OpenOrCreate, isoStore)))
                {
                   string text = reader.ReadToEnd();
                   extrasBrowserControl.Visibility = Visibility.Visible;
                   extrasBrowserControl.NavigateToString(text);
                }
            }
