    public ObservableCollection<string> History
    {
        get { return _history; }
    }
    private void AddToHistory(string item)
    {
        if (!History.Contains(item)) History.Add(item);
    }
