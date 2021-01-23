    private ObservableCollection<string> columnNames = new 
        ObservableCollection<string>();
    public ObservableCollection<string> ColumnNames
    {
        get { return columnNames; }
        set { columnNames = value; NotifyPropertyChanged("ColumnNames"); }
    }
    private string selectedColumnName;
    public string SelectedColumnName
    {
        get { return selectedColumnName; }
        set 
        { 
            selectedColumnName = value;
            NotifyPropertyChanged("SelectedColumnName");
            int index = _names.IndexOf(value); // <<< Changes are reflected here
            Caption = _captions[index];
        }
    }
    private string caption = string.Empty;
    public string Caption 
    {
        get { return caption; }
        set { caption = value; NotifyPropertyChanged("Caption"); }
    }
