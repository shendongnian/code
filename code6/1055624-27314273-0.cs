        [ImportingConstructor]
        public MainViewModel(IEventAggregator events)
        {
            this.events = events;
            this.events.Subscribe(this);
            this.ImageManagement = new ImageManagementViewModel(events);
            this.PreviewUrl = "pack://application:,,,/Resources/placeholder.jpg";
        }
        public String PreviewUrl { get; set; }
        public void Handle(FileSelectedEvent message)
        {
            this.PreviewUrl = message.FilePath;
        }
