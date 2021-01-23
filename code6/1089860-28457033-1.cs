    public class ViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public IEnumerable<StatModifierType> StatModifierTypes
        {
            get { return Enum.GetValues(typeof(StatModifierType)).Cast<StatModifierType>(); }
        }
        public ViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
        }
    }
    public class ItemViewModel : INotifyPropertyChanged
    {
        public ItemViewModel(Item item)
        {
            if(item == null)
                throw new ArgumentNullException("item");
            Name = item.Name;
            Id = item.Id;
            Description = item.Description;
            //This converts our List<StatModifier> to a IEnumerable<StatModifierViewModel>
            var enumerableOfStatViewModels = item.Stats.Select(x => new StatModifierViewModel(x));
            _stats = new ObservableCollection<StatModifierViewModel>(enumerableOfStatViewModels);
        }
        public Item ToModel()
        {
            var item = new Item();
            item.Name = Name;
            item.Id = Id;
            item.Description = Description;
            //This converts our ObservableCollection<StatModifierViewModel> to a IEnumerable<StatModifier>
            var enumerableOfStats = Stats.Select(x => x.StatModifierModel);
            item.Stats = enumerableOfStats.ToList();
        }
        private ObservableCollection<StatModifierViewModel> _stats;
        private string _name;
        private string _id;
        private string _description;
        public ObservableCollection<StatModifierViewModel> Stats
        {
            get { return _stats; }
            set
            {
                if (Equals(value, _stats)) 
                    return;
                _stats = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) 
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Id
        {
            get { return _id; }
            set
            {
                if (value == _id) 
                    return;
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) 
                    return;
                _description = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class StatModifierViewModel : INotifyPropertyChanged
    {
        private readonly StatModifier _statModifier;
        public StatModifierViewModel(StatModifier statModifier)
        {
            //This needs to not be null to not blow up the other functions.
            if(statModifier == null)
                throw new ArgumentNullException("statModifier");
            _statModifier = statModifier;
        }
        public string StatId
        {
            get { return _statModifier.StatId; }
            set
            {
                if (Equals(_statModifier.StatId, value))
                    return;
                _statModifier.StatId = value;
                OnPropertyChanged();
            }
        }
        public StatModifierType Type
        {
            get { return _statModifier.Type; }
            set
            {
                if (Equals(_statModifier.Type, value))
                    return;
                _statModifier.Type = value;
                OnPropertyChanged();
            }
        }
        public float Value
        {
            get { return _statModifier.Value; }
            set
            {
                if (Equals(_statModifier.Value, value))
                    return;
                _statModifier.Value = value;
                OnPropertyChanged();
            }
        }
        
        public StatModifier StatModifierModel
        {
            get { return _statModifier; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
