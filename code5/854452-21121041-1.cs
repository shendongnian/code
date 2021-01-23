    public class ParagonCollection : ObservableCollection<ParagonClass>, INotifyPropertyChanged
    {
      private int sum;
      public int Sum
      { 
        get{ return sum;} 
        set
        {
          sum = value;
          NotifyPropertyChanged("Sum");
        }
     }
      // You'll need as implantation of INotifyPropertyChanged here
      // and some extra stuff to come
      ...
    }
