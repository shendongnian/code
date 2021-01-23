    class ViewModel
    {
        public ObservableCollection<Values> A
        {
            get;
            set;
        }
        public ViewModel()
        {
            A = new ObservableCollection<Values>();
            Values vv = new Values();
            vv.ListOfValues = new ObservableCollection<string>();
            vv.ListOfValues.Add("1");
            vv.ListOfValues.Add("2");
            vv.Selected = vv.ListOfValues[0];
            vv.ValueAvalible = true;
            A.Add(vv);
            A.Add(new Values());
        }
    }
    public class Values : NotifiyPropertyChanged
    {
        public ObservableCollection<string> ListOfValues
        {
            get;
            set;
        }
        private string selectedValue;
        public string Selected
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                Notify("Selected");
            }
        }
        public bool ValueAvalible
        {
            get;
            set;
        }
    }
    public class NotifiyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    }
