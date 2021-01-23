    // implement the interface on your viewmodel
    public class ExampleViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<UIElement> collectionBackingField;
        public  ObservableCollection<UIElement> Collection
        {
            get { return collectionBackingField; }
            set
            {
               if(value != collectionBackingField)
               {
                  collectionBackingField = value;
                    
                  // call the method that notifies all observers of the changes
                  NotifyPropertyChanged();
               }
            }
        }
     }
