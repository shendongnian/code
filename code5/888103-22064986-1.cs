    private ObservableCollection<MyClass> _myCollection 
    public ObservableCollection<MyClass> MyCollection 
    {
    	get { return _myCollection; }
    	set 
    	{
    		_myCollection = value;
    		NotifyPropertyChanged("MyCollection");
    	}
    }
    
    public void InitApp() {
         MyCollection = [... taking data from somewhere ...];
         MyDataGrid.DataContext = this;
    }
    
    <DataGrid ItemsSource="{Binding MyCollection}">
      ...
    </DataGrid>
