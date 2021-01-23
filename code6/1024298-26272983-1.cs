        public ICommand ClosingCommand
        {
            get
            {
                return this._closingCommand ?? (this._closingCommand = new DelegateCommand<CancelEventArgs>((args) =>
                    {
                        //i set a property in app.xaml.cs when i shut down the app there with
                        //Application.Current.Shutdown();
                        if (App.IsShutDown) return;
                    if (this.HasChanges)
                    {
                        var result = _msgService.Show("blup blup", "blup", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (result == MessageBoxResult.No)
                        {
                            args.Cancel = true;
                        }
                    }
                    else
                    {                      
                        var result = MessageBox.Show("Blup blup", "blup", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (result == MessageBoxResult.No)
                        {
                            args.Cancel = true;
                        } 
                    }                    
                }));
            }
        }
