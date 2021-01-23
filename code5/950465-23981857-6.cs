    public ObservableCollection<YourType> YourCollection { get; private set; }
    public DelegateCommand checkCommand { get; private set; }
    
    public YourViewModel(){
        checkCommand = new checkCommand(param => checkExecuted(param));
    }
    
    private void CheckExecuted(Object param)
    {
            YourType item = param as YourType;
            
            YourCollection = new ObservableCollection<YourType>();
            YourCollection = model.ReadInvoices();  //you'll need a model class
            DoStuff(item.yourColumnItem);  //get the cell you want
    }
