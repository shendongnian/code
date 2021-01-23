     private ICommand myCommand;
            public ICommand MyCommand
            {
                get { return this.myCommand; }
                set
                {
                    this.myCommand = value;
                    OnPropertyChanged();
                }
            }
