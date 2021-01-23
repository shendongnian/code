        public ViewModel()
        {
            AddItem = new SimpleCommand(i => Data.Add(new DataViewModel(new DataModel())));
            Save = new SimpleCommand(i =>
                {
                    foreach (var vm in Data)
                    {
                        vm.ValidateAndSave();
                    }
                }
            );
            Data = new ObservableCollection<DataViewModel>();
        }
        public ObservableCollection<DataViewModel> Data { get; set; }
        public ICommand AddItem { get; set; }
        public ICommand Save { get; set; }
