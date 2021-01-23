        public class OtherClass : INotifyPropertyChanged
        {
             private String _someOtherProperty;
        
             public OtherClass(){}
        
                public String someOtherProperty
                {
                    get { return _someOtherProperty; }
                    set
                    {
                        _someOtherProperty= value;
                        OnPropertyChanged("someOtherProperty");
                    }
                }
            
        
             public event PropertyChangedEventHandler PropertyChanged;
            
                private void OnPropertyChanged(string info)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(info));
                    }
                }
        }
