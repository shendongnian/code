        .....
        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (this.clearCommand == null)
                    this.clearCommand = new RelayCommand(() => this.ClearSearch(), ()=> CanSearch());
                return this.clearCommand;
            }
        }
        void ClearSearch()
        {
            Search = string.Empty;
        }
        bool CanSearch()
        {
            return !string.IsNullOrEmpty(_search);
        }
        .....
