    class SomeViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<Resource> ResourceList{
        get{ return value; }
        set
        { 
          _resourceList = value ;
          OnPropertyChanged("ResourceList");
        } 
    
      }
    }
