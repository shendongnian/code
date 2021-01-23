    public class Direction: INotifyPropertyChanged
    {
       private bool _isSelected;
       public bool IsSelected
       {
           get { return _isSelected; }
           set
           {
               _isSelected = value;
               if (OnIsSelectedChanged != null)
                   OnIsSelectedChanged(this);
               
               NotifyPropertyChange(() => IsSelected);
           }
       }
    
       public string DisplayName {get;set;}
    
       public Action<Direction> OnIsSelectedChanged {get;set;}
    }
