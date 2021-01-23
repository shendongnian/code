        private RelayCommand moveRightCommand;
        public RelayCommand MoveRightCommand
        {
            get
            {
                if (moveRightCommand == null)
                {
                    moveRightCommand = new RelayCommand(MoveRight);
                    moveRightCommand.GestureKey = Key.Right;
                }
                return moveRightCommand;
            }
        }
