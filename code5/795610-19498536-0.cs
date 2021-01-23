        public class ViewMole:INotifyPropertyChanged
        {
        public ViewMole()
        {
            ListValues = new List<string>() { "Option1", "Option2", "Option3", "Option4", 
                                               "Option5" };
        }
        public ICommand Click
        {
            get
            {
                return new RelayCommand();
            }
        }
        public List<string> ListValues
        {
            get;
            set;
        }
        string a;
        public string A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                RaisePropertyChanged("A");
            }
        }
        int index=0;
        public int SelectedIndex
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                RaisePropertyChanged("SelectedIndex");
                A = ListValues[index];
                if (index == 0)
                {
                    IsEnabled = false;
                }
                else
                {
                    IsEnabled = true;
                }
            }
        }
        bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
