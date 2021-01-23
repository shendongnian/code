        public ObservableCollection<MenuItem> MainMenu
        {
            get { return _MainMenu; }
            set
            {
                _MainMenu = value;
                NotifyPropertyChanged(x => x.MainMenu);
            }
        }
