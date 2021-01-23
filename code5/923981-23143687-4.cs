        private ObservableCollection<Program> programs; // note lower case p!
        public ObservableCollection<Program> Programs // upper case p!
        {
            get
            { 
                return this.programs; // lower case p!
            }
            set
            {
                this.programs = value; // lower case p
                OnPropertyChanged("Programs");
            }        
        }
