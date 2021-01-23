    public ObservableCollection<yourDataType> TableData
    {
        get { return this.tableData; }
        set
        {
            this.tableData = value;
            this.TableDataWrapper = CollectionViewSource.GetDefaultView(tableData); // Add this
            OnPropertyChanged("tableData");
        }
    }
