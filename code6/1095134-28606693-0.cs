    public class Test : INotifyPropertyChanged
    {
       // explicit interface implementation
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                PropertyChanged += value;
            }
            remove
            {
                PropertyChanged -= value;
            }
        }
        
        // protected virtual (for derived classes to override)   
        protected virtual event PropertyChangedEventHandler PropertyChanged;
    }
