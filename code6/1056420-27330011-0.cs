    for (int i = 0; i <suit.length ; i++) {
        for (int n = 0; n < number.length; n++) { 
            Card c = new Card(suit[i], number[i]); // Card instantiate
            if (deck[i] == null)
            {
                deck[i] = c; // Repeatedly trying to access index 0 to suit.length-1
            }
        }
    }
