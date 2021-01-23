    public class MainViewModel : ViewModelBase
    {
        private IDataFactory _DataFactory;
        public MainViewModel()
        {
            _DataFactory = new DesignTimeMockDataFactory();
            LoadData();
        }
        [PreferredConstructor]
        public MainViewModel(IDataFactory dataFactory)
        { _DataFactory = dataFactory; }
        public void LoadData()
        { DataItems.AddRange(_DataFactory.GetDataItems()); }
        public ExtendedObservableCollection<DataItem> DataItems { get; private set; }
    }
