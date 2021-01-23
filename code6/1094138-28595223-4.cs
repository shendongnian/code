    public MainViewViewModel(RepositoryPoller<string> repositoryPoller)
    {
        RepositoryPoller = repositoryPoller;
        // If you prefer pub/sub...
        Messenger.Default.Register<GenericMessage<IEnumerable<string>>>(this, message =>
            {
                var results = message.Content;
                Items = new ObservableCollection<string>(results);
            });
        // Or in case events feel more liek home
        RepositoryPoller.OnQueryComplete += (sender, args) =>
            {
                var results = args.Results;
                Items = new ObservableCollection<string>(results);
            };
        RepositoryPoller.Start();
    }
    public RepositoryPoller<string> RepositoryPoller { get; set; }
