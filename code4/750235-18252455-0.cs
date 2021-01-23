    public class OptionProperty : INotifyPropertyChanged
    {
        public MyOptions MyOptions { get; set; }
        
        public DependencyProperty OptionDependencyProperty { get; set; }
        
        public object Value
        {
            get
            {
                return MyOptions.GetValue(OptionDependencyProperty);
            }
            set
            {
                MyOptions.SetValue(OptionDependencyProperty, value);
                RaisePropertyChanged("Value");
            }
        }
        // TODO Implement INotifyPropertyChanged
        // TODO All of the other properties
    }
