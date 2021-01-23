    public bool IsStraightFlush(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => card.Face).ThenBy(card => card.Suit).ToList();
            bool straightFlush = true;
            for (int i = 1; i < sortedCards.Count(); i++)
            {
                if ((int)sortedCards[i].Face != (int)sortedCards[i - 1].Face + 1)
                {
                    straightFlush = false;
                    break;
                }
            }
            return straightFlush;
        }
