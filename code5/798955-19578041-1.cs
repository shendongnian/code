    private List<GroupAndEffect> _groupAndEffects;
        public List<GroupAndEffect> GroupsAndEffects
        {
            get
            {
                return _groupAndEffects;
            }
            set
            {
                _groupAndEffects = value;
                OnPropertyChanged("GroupsAndEffects");
            }
        }
 
