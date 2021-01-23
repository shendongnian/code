    private RelayCommand _mouseLeftButtonUpCommand;
        public RelayCommand MouseLeftButtonUpCommand
        {
            get
            {
                return _mouseLeftButtonUpCommand 
                    ?? (_mouseLeftButtonUpCommand = new RelayCommand(
                    () =>
                    {
                        // the handler goes here 
                    }));
            }
        }
   
