    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _myCheckValue;
        public bool MyCheckValue
        {
            get { return _myCheckValue; }
            set 
            {
                _myCheckValue = value;
                this.RaisePropertyChanged("MyCheckValue");
            }
        }
        //INotifyPropertyChange implementation not included...
    }
