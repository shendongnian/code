    [Test]
    public void CheckCorrectNumberOfCardsAreReturned()
    {
      List<Card> allCards = GenerateDeck();
      var deck = new Deck(allCards);
      var drawnCards = deck.DrawSorted(5);
      Assert.AreEqual(5, drawnCards.Count());
    }
