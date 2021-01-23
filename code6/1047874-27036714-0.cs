        CommandManager.RequerySuggested += CommandManager_RequerySuggested;
        private void CommandManager_RequerySuggested(object sender, EventArgs e)
        {
            this.MyCommand.CanExecute = "..." 
        }
