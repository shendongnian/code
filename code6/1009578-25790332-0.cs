     public class  ViewModel:INotifyPropertyChanged  
    
            {
            public  int Counter
            {
                get { return _counter;  }
                set {
                    _counter = value; 
                     RaisePropChanged("Counter");
                    //for example 
                    if (value>3)
                    {
                        IsButtonCounterEnabled = true;  
                    }
                    else
                    {
                        IsButtonCounterEnabled = false;  
    
    
                    }
                }
            }
            public bool IsButtonCounterEnabled
            {
                get { return _IsButtonCounterEnabled;   }
                set { _IsButtonCounterEnabled = value;  
                      RaisePropChanged("IsButtonCounterEnabled");
                    }
            }
            private  void RaisePropChanged(string propName)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propName));   
    
            }
                 
            
                public event PropertyChangedEventHandler PropertyChanged = delegate{};
                private int _counter;
                private bool _IsButtonCounterEnabled;
    }
