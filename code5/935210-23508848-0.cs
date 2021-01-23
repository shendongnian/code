    var filesNames = store.GetFileNames();
    var titles = new List<string>();
    foreach (var fileName in fileNames)
    {
        using (var sr = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, isf)))
        {
            titles.Add(sr.ReadLine());
        }
    }
    this.NotesListBox.ItemsSource = titles;
