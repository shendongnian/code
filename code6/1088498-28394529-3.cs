    namespace WpfApplication1
    {
        public class Party : INotifyPropertyChanged
        {
            private bool isSelected;
            private string name;
            private string surname;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    if (isSelected != value)
                    {
                        isSelected = value;
                        OnPropertyChanged("IsSelected");
                    }
                }
            }
    
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }
    
            public string Surname
            {
                get
                {
                    return surname;
                }
                set
                {
                    if (surname != value)
                    {
                        surname = value;
                        OnPropertyChanged("Surname");
                    }
                }
            }
    
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
