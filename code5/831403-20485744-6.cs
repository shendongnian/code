    private void FillItems()
    {
       Fico = new ObservableCollection<string> { "Animal one", "Animal two" , "Animal three"};
       Seco = new ObservableCollection<string> { "All", "Baby" };    
    }
    public ObservableCollection<string> Fico { get; set; }
    public ObservableCollection<string> Seco { get; set; }
