    using (System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName))
    {
    	Card newcard = new Card();
    	newcard.CardName = file.ReadLine();
    	newcard.NumBorrowed = Convert.ToInt32(file.ReadLine());
    	cardlist.Add(newcard);
    }
