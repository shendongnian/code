    class GlobalRepository
    {
        private Dictionary<Type, Repository<ViewModelBase> _repoDict;
        public GlobalRepository()
        {
            _repoDict = new Dictionary<Type, Repository<ViewModelBase>>();
            //Guess here could be some Assembly lookup for all derived classes
            //But if you do not intend to expand them a lot, it can be hardcoded
            Repository<ViewModelBaseType> repo = new Repository<ViewModelBaseType>()
            _repoDict.Add(ViewModelBaseType, repo);            
                //the similar for all of the repositories
        }
        public ObservableCollection<ViewModelBase> Get(Type t)
        {
            if(!_repoDict.ContainsKey(typeof(t)){
                //throw your argument exception here
            }
            Repository<ViewModelBase> repo;
            _repoDict.TryGetValue(t, repo);
            ObservableCollection<t> collection = repo.Get();
            return collection;
        }
    }
