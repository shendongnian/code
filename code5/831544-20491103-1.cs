    class SampleViewModel : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
    
            private double inputA = 0;
    
            public double InputA
            {
                get { return inputA; }
                set 
                { 
                    inputA = value;
                    OnPropertyChanged("InputA");
                    UpdateHasError();
                }
            }
    
            private double inputB = 0;
    
            public double InputB
            {
                get { return inputB; }
                set 
                { 
                    inputB = value;
                    OnPropertyChanged("InputB");
                    UpdateHasError();
                }
            }
    
            private bool hasError;
    
            public bool HasError
            {
                get { return hasError; }
                set 
                { 
                    hasError = value;
                    OnPropertyChanged("HasError");
                }
            }
    
            private void UpdateHasError()
            {
                //If inputA and inputB decimal we update hasError
                if(inputA > 0 && inputB > 0)
                    HasError = true;
                else
                    HasError = false;
            }
        }
