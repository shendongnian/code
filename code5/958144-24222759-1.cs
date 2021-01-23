        private RelayCommand moveRightCommand;
        public RelayCommand MoveRightCommand
        {
            get
            {               
                return moveRightCommand;
            }
            set
            {
                moveRightCommand = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MoveRightCommand"));
            }
        }
 
            
