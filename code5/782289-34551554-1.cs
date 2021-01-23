        private void SetupCommands()
        {
            CloseCommand = new RelayCommand(CloseApplication);
            MinimizeCommand = new RelayCommand(MinimizeApplication);
        }
