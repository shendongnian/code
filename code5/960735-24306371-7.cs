        public ICommand KeyBoardHotKeyCommand { get; set; }
        public ViewModel()
        {
            KeyBoardHotKeyCommand = new RelayCommand(ExecuteKeyboardHotKeyCommand, CanExecuteKeyboardHotKeyCommand);
        }
        private void ExecuteKeyboardHotKeyCommand(object obj)
        {
            Notes note;
            if (obj!=null && Enum.TryParse(obj.ToString(), out note))
            {
                Console.WriteLine(@"User pressed {0}", note);
            }
        }
        private bool CanExecuteKeyboardHotKeyCommand(object obj)
        {
            return true;
        }
