class MainWindowViewModel : INotifyPropertyChanged 
{
    public event PropertyChangedEventHandler PropertyChanged;
    public List<ListingItem> Listing { get; set; }
    public CommandHandler FillListCommand { get; set; }
    public MainWindowViewModel()
    {
        FillListCommand = new CommandHandler(DoFillList);
    }
    public void DoFillList()
    {
        Listing = ListMaker.getListing();
        ProperyHasChanged("Listing");
    }
    private void ProperyHasChanged(string propertyName)
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
   
}
