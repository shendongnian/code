     public class KeyValueRow<K,V>:INotifyPropertyChanged
        {
            public  KeyValueRow(K key,V value)
            {
                this.Key = key;
                this.Value = value; 
            }
            private K _key;
            private V _value;  
                 
            public K Key
            {
                get { return _key;  }
                set
                {
                    if (!EqualityComparer<K>.Default.Equals(_key, value)) 
                    {
                        _key = value;  
                        RaisePropertyChanged("Key");
                    }
                }
            }
    
            private void RaisePropertyChanged(string p)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));  
            }
            public V Value
            {
                get { return _value; }
                set
                {
                    if (!EqualityComparer<V>.Default.Equals(_value, value))
                    {
                       _value = value;
                       RaisePropertyChanged("Value");
                    }
                }
            }              
            //prefarble way  as it evit to check the for null when raising  event 
            public event PropertyChangedEventHandler PropertyChanged = delegate{};
    
        }
