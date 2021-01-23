    public interface IHand {
        List<Card> CurrentHand { get; }
    }
    public interface IDealerHand : IHand {
    }
    public interface IPlayerHand : IHand {
    }
    public class Hand : IDealerHand, IPlayerHand{
        private List<Card> cardsHeld;
        // The implementation here will ensure that only a single card for the dealer is shown.
        List<Card> IDealerHand.CurrentHand { get { return cardsHeld.Take(1); } }
        // The implementation here will ensure that all cards are exposed.
        List<Card> IPlayerHand.CurrentHand { get { return cardsHeld; } }
    }
 
