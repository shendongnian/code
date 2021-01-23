        public ObservableCollection<string> Items
        {
            get;
            set;
        }
        public ICommand Navigate
        {
            get
            {
                return new RelayCommand(
                    (param) => DoNavigate(param as string), // execute
                    (param) =>                              // can execute
                    {
                        var link = param as string;
                        return link != "SH";
                    });
            }
        }
