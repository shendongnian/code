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
    
            public string InputA
            {
              get { return inputA.ToString(); }
              set 
              { 
                if(double.TryParse(value, out inputA))
		{
		 OnPropertyChanged("InputA");
                 UpdateHasError();
		}                
              }
            }
    
            private double inputB = 0;
    
            public string InputB
            {
              get { return inputB.ToString(); }
              set 
              { 
                if(double.TryParse(value, out inputB))
		{
		 OnPropertyChanged("InputB");
                 UpdateHasError();
		}                
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
