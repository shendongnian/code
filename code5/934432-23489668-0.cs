    public ObservableCollection<RecordModel> Files
    {
        get { return _files; }
        set
        {
            if (_files == value) return;
        
            _files = value;
            OnPropertyChanged("Files");
            PrintCommand.CanExecute(null);
        }
    }
