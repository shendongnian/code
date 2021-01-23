    ArrayList groupA = new ArrayList();
        ArrayList groupB = new ArrayList();
        ArrayList groupC = new ArrayList();
        ArrayList groupD = new ArrayList();
        ArrayList groupE = new ArrayList();
        ArrayList groupF = new ArrayList();
        ArrayList groupG = new ArrayList();
        ArrayList groupH = new ArrayList();	
		
		for (int i = 0; i < 40; i++)
		{
			if (i < 10)
				groupA.Add(new room(5000, "A" + (i + 1)));
			if (i < 10)
				groupB.Add(new room(4000, "B" + (i + 1)));
			if (i < 30)
				groupC.Add(new room(3500, "C" + (i + 1)));
			if (i < 36)
				groupD.Add(new room(3400, "D" + (i + 1)));
			if (i < 40)
				groupE.Add(new room(3300, "E" + (i + 1)));
			if (i < 30)
				groupF.Add(new room(3400, "F" + (i + 1)));
			if (i < 36)
				groupG.Add(new room(3300, "G" + (i + 1)));
			if (i < 40)
				groupH.Add(new room(3200, "H" + (i + 1)));			
		}
		
		ship1.addDeck("Balcony Suite", groupA);
        ship1.addDeck("Suite", groupB);
        ship1.addDeck("Deck 3 - Outside Twin", groupC);
        ship1.addDeck("Deck 2 - Outside Twin", groupD);
        ship1.addDeck("Deck 1 - Outside Twin", groupE);
        ship1.addDeck("Deck 3 - Inside Twin", groupF);
        ship1.addDeck("Deck 2 - Inside Twin", groupG);
        ship1.addDeck("Deck 1 - Inside Twin", groupH);   
