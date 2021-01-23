    public partial class Card {
        public CardStatus LastStatus
        {
            get
            {
                return cardStatus.Last();
            }
        }
    }
