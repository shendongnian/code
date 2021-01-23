     private Visibility _comboboxvisibility;
       public Visibility comboboxvisibility
       {
           get { return _comboboxvisibility; }
           set { _comboboxvisibility = value; RaisePropertyChanged("comboboxvisibility"); }
       }
       private XyZListItem _selectedItem;
       public XyZListItem SelectedItem
       {
           get { return _selectedItem; }
           set {
               comboboxvisibility = Visibility.Collapsed;         
        }
       }
