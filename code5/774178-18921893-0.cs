    public class ViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Emp> Employees
        {
           get { return _employees; }
           set
           {
               if (_employees != value)
               {
                   _employees = value;
                   OnPropertyChanged("Employees");
               }
           }
        }
        /* ... */
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
