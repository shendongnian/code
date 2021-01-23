    private ObservableCollection<int> numbers = new ObservableCollection<int>();
    public ObservableCollection<int> Numbers
    {
        get { return numbers; }
        set { numbers = value; NotifyPropertyChanged("Numbers"); }
    }
    ...
    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Numbers.Insert(2, 10);
    }
