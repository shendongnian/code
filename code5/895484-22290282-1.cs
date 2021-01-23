    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if(NavigationContext.QueryString.ContainsKey("note"))
        {
            _openSavedFile(NavigationContext.QueryString["note"]);
        }
        
        base.OnNavigatedTo(e);
    }
    private _openSavedFile(string filename)
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        using (var stream = new IsolatedStorageFileStream(filename, FileMode.Open, FileAccess.ReadWrite, store))
        {
            StreamReader reader = new StreamReader(stream);
            this.NoteTextBox.Text = reader.ReadToEnd();
            this.FilenameTextBox.Text = filename;
            reader.Close();
        }
    }
