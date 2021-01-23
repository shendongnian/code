    int lineCount=0;
    string line=string.Empty;
    using (System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName))
    {
    	Card newcard = new Card();
        while((line=file.ReadLine()) != null)
        {
        if(lineCount == 0)
        {
    	 newcard.CardName = line;
         lineCount = 1;
        }
        else if(lineCount == 1)
        {
    	 newcard.NumBorrowed = Convert.ToInt32(line);
         lineCount = 0;
        }
    	 cardlist.Add(newcard);
    }
