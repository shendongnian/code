    public class OwnerDef : INotifyPropertyChanged   // TODO implement INotifyPropertyChanged 
    {
        public OwnerTypeDef OwnerType
        {
            get { return _ownerType; }
            set
            {
                if (_ownerType == value)
                    return;
                _ownerType = value;
                RaisePropertyChanged();
            }
        }
        private OwnerTypeDef _ownerType;
    }
    public class OwnerTypeDef : INotifyPropertyChanged
    {
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                RaisePropertyChanged();
            }
        }
        private string _name;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                RaisePropertyChanged();
            }
        }
        private int _id;
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public List<OwnerTypeDef> OwnerTypes
        {
            get { return _ownerTypes; }
            set { _ownerTypes = value; }
        }
        private List<OwnerTypeDef> _ownerTypes = new List<OwnerTypeDef>
            {
                new OwnerTypeDef { Name = "foo", Id = 1, },
                new OwnerTypeDef { Name = "bar", Id = 2, },
                new OwnerTypeDef { Name = "baz", Id = 3, },
            };
        public OwnerDef Owner
        {
            get { return _owner; }
            set
            {
                if (_owner == value)
                    return;
                _owner = value;
                RaisePropertyChanged();
            }
        }
        private OwnerDef _owner = new OwnerDef();
    }
