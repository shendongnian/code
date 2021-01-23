    public class MyXmlObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set
            {
                fieldName = value;
                NotifyPropertyChanged("FieldName");
            }
        }
        NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
