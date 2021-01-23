        class CardInfo
        {
            public string CardDetails { get; set; }
        }
        class CardSwipedEventArgs 
            : EventArgs
        {
            public CardInfo SwipedCard { get; set; }
        }
        interface ICardReader
        {
            event EventHandler<CardSwipedEventArgs> CardSwiped;
        }
        class MyViewModel : INotifyPropertyChanged
        {
            private ICardReader _cardReader;
            private string _lastCardSwiped;
            public ICardReader CardReader
            {
                get
                {
                    return _cardReader;
                }
                set
                {
                    _cardReader = value;
                    _cardReader.CardSwiped += OnCardSwiped;
                }
            }
            private void OnCardSwiped(object sender, CardSwipedEventArgs e)
            {
                LastCardSwiped = e.SwipedCard.CardDetails;
            }
            public string LastCardSwiped
            {
                get
                {
                    return _lastCardSwiped;
                }
                set
                {
                    _lastCardSwiped = value;
                    this.OnPropertyChanged("LastCardSwiped");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
