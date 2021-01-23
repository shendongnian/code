    public class MyViewModel:INotifyPropertyChanged
        {
            public MyViewModel()
            {
    
            }
    
            private double valueSlider1;
            public double ValueSlider1
            {
               get { return valueSlider1; }
               set
               {
                  valueSlider1 = value;
                  RaisePropertyChanged("ValueSlider1");
                  RaisePropertyChanged("TotalValue ");
               }
            }
            private double valueSlider2;
            public double ValueSlider2
            {
               get { return valueSlider2; }
               set
               {
                  valueSlider2 = value;
                  RaisePropertyChanged("ValueSlider2");
                  RaisePropertyChanged("TotalValue ");
               }
            }
            private double valueSlider3;
            public double ValueSlider3
            {
               get { return valueSlider3; }
               set
               {
                  valueSlider3 = value;
                  RaisePropertyChanged("ValueSlider3");
                  RaisePropertyChanged("TotalValue ");
               }
            }
            public double TotalValue
            {
               get { return ValueSlider1*100+ValueSlider2*10+ValueSlider3; }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string propertyName)
            {
                 var handler = this.PropertyChanged;
                 if (handler != null)
                 {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                 }
            }
        }
