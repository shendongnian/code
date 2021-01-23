    public DeckItem GameDeck
    {
        get { return _gameDeck.Entity; }
        set
        {
            NotifyPropertyChanging("GameDeck");
            _gameDeck.Entity = value;
            if (value != null)
            {
                _gameDeckId = value.DeckId;
            }
            NotifyPropertyChanging("GameDeck");
        }
    }
