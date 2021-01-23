    using System.Collections.Generic;
    
    class Card {}
    
    class Deck
    {
        public ICollection<Card> Cards { get; private set; }
    
        public Card this[int index]
        {
            get { return System.Linq.Enumerable.ElementAt(Cards, index); }
        }
    }
