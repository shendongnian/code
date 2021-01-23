    public RelayCommand RequestCloseCommand { get; private set; }
    void RequestClose()
    {
        // if you want to prevent the document closing, just return from this function
        // otherwise, close it by removing it from the collection of DocumentVMs
        this.DocumentManagerVM.DocumentVMs.Remove(this);
    }
