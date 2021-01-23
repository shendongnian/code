    public class User
    {
        string _Name;
        public string Name 
        {
            get { return _Name; }
            set {
                _Name = value;
                PropertyChanged("Name");
            }
    ...
        }
    }
