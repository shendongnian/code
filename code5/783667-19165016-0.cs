      foreach (string crd in from c in MyDeck.MyCards select c.getCardName() )
      {
         if ( MagCards.Contains( crd ) )
         {
            break;
         }
         else
         {
            Card cd = new Card(MagCard);
            MyDeck.MyCards.Add(cd);
         }
      }
