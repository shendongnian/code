    class Card : VMBase
    {
        private readonly Action<Card> _addCard;
        public Card(..., Action<Card> addCard)
        {
            ...
            _addCard = addCard;
            this.PickCardCommand = new MvvmCommand();
            this.PickCardCommand.CanExecuteFunc = obj => true;
            this.PickCardCommand.ExecuteFunction = PickCard;
        }
        public MvvmCommand PickCardCommand { get; set; }
        public void PickCard(object parameter)
        {
            _addCard(this);
        }
    }
