    public class SomeModel : INotifyPropertyChanged
    {
        private string textField;
        private bool boolField;
        public event PropertyChangedEventHandler PropertyChanged;
        public string TextField
        {
            get { return textField; }
            set
            {
                if (value == textField) return;
                textField = value;
                OnPropertyChanged();
            }
        }
        public bool BoolField
        {
            get { return boolField; }
            set
            {
                if (value.Equals(boolField)) return;
                boolField = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
