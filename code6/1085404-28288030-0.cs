           System.Random rnd = new System.Random();
           for (int i = 0; i<52; i++) {
                Card newCard = new Card(rnd.Next(1,13), rnd.Next(1,4));
                if (!deckList.Contains(newCard) || i == 0) {
                    deckList.Add(newCard);
                } else { i--; }
            }
