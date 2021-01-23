    using System.Collections.Generic;
    using System.Linq; // This line is required to use Linq extension methods
    
    class Card {}
    
    class Deck
    {
        public ICollection<Card> Cards { get; private set; }
    
        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
    }
