    private ICommand renameItemCommand;
        public ICommand RenameItemCommand
        {
            get
            {
                if (renameItemCommand == null)
                {
                    renameItemCommand = new RelayCommand(
                                           param => RenameItem()
                                       );
                }
                return renameItemCommand;
            }
        }
    private void RenameItem()
    {
    }
