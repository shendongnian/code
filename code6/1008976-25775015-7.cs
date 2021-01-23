    public ICommand SelectedItemChangedCommand{ get; set;}
    // somewhere in your code..
    SelectedItemChangedCommand = new RelayCommand<SelectedItemChangedCommand>(OnSelectedItemChanged);
    protected void OnSelectedItemChanged(SelectedItemChangedCommand e)
    {
       // Do your magic here! Or why not just call this method from the setter of your bound property?
    }
