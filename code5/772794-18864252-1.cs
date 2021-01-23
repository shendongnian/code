    public class myViewModel : INotifyPropertyChanged
    {
        private MyEntityObject _myObject;
        public MyEntityObject MyObject
        {
            get { return _myObject; }
            set {
                if (_myObject != value)
                {
                    _myObject = value;
                    OnPropertyChanged("MyObject");
                }
            }
        }
        
        private void _nextRecord()
        {
          MyObject = myEntitiesObject.NextRecord() //pseudocode
        }
    }
