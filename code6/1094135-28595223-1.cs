    // ViewModelBase just implements the INotifyPropertyChanged
    public class MainViewViewModel : ViewModelBase
    {
        private ObservableCollection<string> _items;
        public MainViewViewModel()
            : this(new SimpleRepository())
        {}
        // pass in the repository dependency
        public MainViewViewModel(IRepository<string> simpleRepository)
        {
            SimpleRepository = simpleRepository;
            Task.Run(async () =>
                {
                    // sophisticated polling logic here
                    while (true)
                    {
                        // update collection
                        var results = await SimpleRepository.GetAll();
                        Items = new ObservableCollection<string>(results);
                        Thread.Sleep(250);
                    }
                });
        }
        public IRepository<string> SimpleRepository { get; set; }
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged();}
        }
    }
