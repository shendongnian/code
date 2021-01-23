    public class DataModel
    {
        public object Value1 { get; set; }
        public object Value2 { get; set; }
    }
    public class DataViewModel : INotifyPropertyChanged
    {
        DataModel model;
        public DataViewModel(DataModel model)
        {
            this.model = model;
            IsValid = true;
        }
        object _value1;
        public object Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                _value1 = value;
            }
        }
        object _value2;
        public object Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
            }
        }
        public bool IsValid { get; set; }
        public void ValidateAndSave()
        {
            IsValid = !(_value1 != null && _value2 == null);
            PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
            if (IsValid)
            {
                model.Value1 = _value1;
                model.Value2 = _value2;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
