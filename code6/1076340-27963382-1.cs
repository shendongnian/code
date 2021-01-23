        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                    _clickCommand = new RelayCommand(p => this.DoMyCommand(p),p => this.CanDoMyCommand(p));
                return _clickCommand;
            }
        }
        private bool CanDoMyCommand(object p)
        {
            ////enable or disable your command here
            return true;
        }
        private object DoMyCommand(object p)
        {
            ////operations of command execution goes here.
            return null;
        }
