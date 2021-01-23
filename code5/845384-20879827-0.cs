         private ObservableCollection<YourObject> _list;
        public ObservableCollection<YourObject> List{
        get{ return _list;}
        set{ return _list = value;RaisePropertyChanged("List");}
    }
    private yourObjectType _selectedItem;
        public yourObjectType  SelectedItem{
        get{ return _selectedItem;}
        set{ return _selectedItem= value;RaisePropertyChanged("SelectedItem");}
    //here your can do anything}
    }
