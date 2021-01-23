    bool _isExpandedPropertyOnViewModel=false;
    public bool IsExpandedPropertyOnViewModel{
       get { return _isExpandedPropertyOnViewModel;}
       set
       {
          if(CanMultiSelect)
          {
             _isExpandedPropertyOnViewModel=false;     
          }
          else
             _isExpandedPropertyOnViewModel=value;     
          NotifyPropertyChanged(...);
       }
    }
