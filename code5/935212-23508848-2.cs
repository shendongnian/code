    // put this in your view class
    private List<Note> _notes;
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) 
    { 
        _notes = new List<Note>();
        var filesNames = store.GetFileNames();
        foreach (var fileName in fileNames)
        {
            using (var sr = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, isf)))
            {
                var note = new Note();
                note.FileName = fileName;
                note.Title = sr.ReadLine();
                note.Body = sr.ReadToEnd();
                _notes.Add(note);
            }
        }
        this.NotesListBox.ItemsSource = _notes;
    } 
