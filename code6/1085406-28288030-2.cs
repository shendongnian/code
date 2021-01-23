           System.Random rnd = new System.Random();
           for (int i = 0; i<52; i++) {
                Card newCard = new Card(rnd.Next(1,14), rnd.Next(1,5));
                if (!deckList.Contains(newCard) || i == 0) {
                    deckList.Add(newCard);
                } else { i--; }
            }
