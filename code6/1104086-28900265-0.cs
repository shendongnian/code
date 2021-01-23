    private Project _LoadedProject;
        public Project LoadedProject
        {
            get { return _LoadedProject; }
            set 
            { 
                _LoadedProject = value;
                OnPropertyChanged("LoadedProject");
            }
        }
