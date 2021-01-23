    public class DisplayItemBase<T> : ObservableObject 
    {
       private T _Item;
       public T Item
       {
          get { return _Item; }
          set
          {
             if (value == _Item)
                return;
             _Item = value;
             RaisePropertyChanged("Item");
          }
       }
       private bool _IsSelected;
       public bool IsSelected
       {
          get { return _Item; }
          set
          {
             if (value == _Item)
                return;
             _Item = value;
             RaisePropertyChanged("Item");
          }
       }
       //More reusable properties/methods/etc
    }
