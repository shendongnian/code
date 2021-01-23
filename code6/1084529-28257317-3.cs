    public class MainViewModel:ViewModelBase
    {
        private ObservableCollection<IAB> _collection;
        public ObservableCollection<IAB> Collection
        {
            get { return _collection; }
            set
            {
                if (value != this._collection)
                    _collection = value;
                SetPropertyChanged("Collection");
            }
        }
        public MainViewModel()
        {
            var m_model = new CClassModel();
            Collection=new ObservableCollection<IAB>(m_model.Items);
        }
    }
