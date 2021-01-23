    class MainWindowViewModel : ViewModelBase
    {
      // Make sure you implement INotifyPropertyChanged and invoke on each property!
    
      public string Title { get; set; }
    
      public ObservableCollection<DatabaseTableViewModel> Tables { get; set; }
    
      public DatabaseTableViewModel SelectedTable { get; set; }
    }
    
    class DatabaseTableViewModel : ViewModelBase
    {
      public string TableName { get; set; }
       
      public ObservableCollection<DatabaseTableColumnViewModel> Columns { get; set; }
    }
    
    class DatabaseTableColumnTableViewModel : ViewModelBase
    {
      public string ColumnName { get; set; }
      public string ColumnType { get; set; }
      public DatabaseTableColumnViewModel SelectedColumn { get; set; }
    }
