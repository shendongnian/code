        public ViewModelUnderTest(IRepository repo, IScheduler scheduler)
        {
            _repo = repo;
            _scheduler = scheduler;
            LoadJobCommand = new RelayCommand(ExecuteLoadJobCommandAsync);
        }
        private void ExecuteLoadJobCommandAsync()
        {
            _scheduler.Execute(GetData);
        }
        private void GetData()
        {
            var a =  _repo.GetData().Result;
            Jobs.Add(a);
        }
