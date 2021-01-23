    public class Deck
    {
        private List<Card> cards;
        
        public Deck()
        {
            cards = new List<Card>();
        }
        public void Add(Card card)
        {
            if (cards.Count == 52)
            { 
                throw new TooManyCardsException();
            }
            cards.Add(card);
        }
    
        public void Remove();
        {
            ...
        }
    
        ....
    }
