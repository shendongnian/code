    public class A : INotifyPropertyChanged 
    {
        public String SomeProperty {....}
        ...
    }
    public YourViewModel : YourViewModelBase 
    {
       private ObservableCollection<A> yourItems_ = new ObservableCollection<A>();
       public ObservableCollection YourItems {
           get { return yourItems_;}
           set { if( yourItems_!=value ) {
                   _yourItems = value;
                   OnPropertyChanged();
                 }
                 return _yourItems;
           }
      
          }
    }
