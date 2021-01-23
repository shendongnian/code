    private int _selectedItem;
    public int SelectedItem
    {
       get { return _selectedItem; }
       set
          {
             _selectedItem = value;
             OnPropertyChanged("SelectedItem");
          
          }
    }
