      public class ViewModel : INotifyPropertyChanged {
        public ViewModel() {
            this.values = new ObservableCollection<string>()
            {
                "first",
                "second",
                "third"
            };
        }
        ObservableCollection<string> values;
        string selectedValue;
        public ObservableCollection<string> Values { get { return values; } }        
        public string SelectedValue {
            get { return selectedValue; }
            set {
                if (Equals(selectedValue, values))
                    return;
                selectedValue = value;
                if (PropertyChanged == null)
                    return;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedValue"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
