    using (System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName))
    {
        string line;
    
        while ((line = file.ReadLine()) != null)
        {
            Card newcard = new Card();
            newcard.CardName = line;
            newcard.NumBorrowed = Convert.ToInt32(line);
            cardlist.Add(newcard);
        }
    }
