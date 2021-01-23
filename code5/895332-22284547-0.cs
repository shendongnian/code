        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            base.OnNavigatedTo(e);
            string filename = "";            
            if ( NavigationContext.QueryString.TryGetValue("note", out filename ) && !string.IsNullOrEmpty(filename))
            {
                using (var store = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication())
                using (var stream = new IsolatedStorageFileStream(filename, FileMode.Open, FileAccess.ReadWrite, store))
                {
                    StreamReader reader = new StreamReader(stream);
                    this.NoteTextBox.Text = reader.ReadToEnd();
                    this.FilenameTextBox.Text = filename; reader.Close();
                }
            }
            
        }
