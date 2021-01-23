    List<Cards> wholeDeck = new List<Cards> { // initialize with a complete deck }
    Random r = new Random();
    Stack<Cards> stackOfCards = new Stack<Cards>();
    while (wholeDeck.Count > 0) {
        var aCard = wholeDeck[r.Next(0,wholeDeck.Count)];     // grab a random card
        stackOfCards.Push(aCard);                              // push it on the stack
        wholeDeck.Remove(aCard);                              // remove it from the original list
    }
