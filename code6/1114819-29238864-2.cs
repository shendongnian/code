            //Model
        public class Calculation : INotifyPropertyChanged
        {
            private string _calcProgVisibility;
            public string CalcProgVisibility
            {
                get { return _calcProgVisibility; }
                set
                {
                    _calcProgVisibility = value;
                    OnPropertyChanged("CalcProgVisibility");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                RaisePropertyChanged(propertyName);
            }
            private void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler == null) return;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //ViewModel
        public class ViewModel : INotifyPropertyChanged
        {
            public ViewModel(Calculation model)
            {
                this.CalcProgVisibility = model.CalcProgVisibility;
                model.PropertyChanged += (s, e) => UpdateEntity(s as Calculation);
            }
            private void UpdateEntity(Calculation source)
            {
                CalcProgVisibility = source.CalcProgVisibility;
            }      
            private string _calcProgVisibility;
            public string CalcProgVisibility
            {
                get { return _calcProgVisibility; }
                set
                {
                    _calcProgVisibility = value;
                    OnPropertyChanged("CalcProgVisibility");
                }
            }
             public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                RaisePropertyChanged(propertyName);
            }
            private void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler == null) return;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
