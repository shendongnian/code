    public class MainViewModel 
    {
        // if feeling lazy, provide default dependencies
        public MainViewModel()
            :this(new ModelRepository()) 
        {}
        // attribute for IoC/dependency injection
        [PreferredConstructor]
        public MainViewModel(RepositoryBase<Model> modelRepository)
        {
            ModelRepository = modelRepository;
            Task.Factory.StartNew(() => Initialize());
        }
        public RepositoryBase<Model> ModelRepository { get; set;}
        private async Task Initialize()
        {
            // Do stuff
        }
    }
