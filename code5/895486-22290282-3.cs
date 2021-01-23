    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if(NavigationContext.QueryString == null)
        {
            //QueryString is null
        }
        else if (NavigationContext.QueryString.ContainsKey("note"))
        {
            _openSavedFile(NavigationContext.QueryString["note"]);
        }
        else
        {
            //QueryString does not contain a "note" parameter and QueryString is not null
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
