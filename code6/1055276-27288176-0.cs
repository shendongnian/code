        public DelegateCommand<int> NoOfRecords { get; set; }
        public HomeViewModel()
        {
            NoOfRecords = new DelegateCommand<int>(Number);
        }
        private void Number(int value)
        {
            // Do your logic
        }
